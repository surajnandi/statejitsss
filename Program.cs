using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Npgsql;
using statejitsss.Authentication.JWT;
using statejitsss.DAL;
using statejitsss.Dependency;
using statejitsss.Helpers;
using statejitsss.Middleware;
using statejitsss.RabbitMQ.Extension;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

// Add services to the container.
builder.Services.AddStateJitDependencies();

/* ========== RabbitMQ Configuration ========== */
//builder.Services
//   .AddRabbitMQ(builder.Configuration)
//   .AddMessageProcessing();

builder.Services.AddDbContext<StateJitDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StateJitDBConnection"),
    //options => options.CommandTimeout(999)
    options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
), ServiceLifetime.Scoped);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IDbConnection>(sp =>
        new NpgsqlConnection(builder.Configuration.GetConnectionString("StateJitDBConnection")));

builder.Services.AddHealthChecks();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

builder.Services.AddSignalRServices();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication();

builder.Services.AddAuthorizationPolicies();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "STATE JIT SSS - Version_1.0.0",
            Version = "v1",
            Description = "STATE JIT SSS WEB API",
        }
    );
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("RestrictedPolicy", policy =>
        policy.WithOrigins(
                "https://train-ifms.wb.gov.in",
                "https://ifms.wb.gov.in")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());

    options.AddPolicy("AllowAllPolicy", policy =>
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

var app = builder.Build();

app.UseHsts();
app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("Server");
    context.Response.Headers.Remove("X-Powered-By");
    context.Response.Headers.Remove("X-AspNet-Version");
    context.Response.Headers.Remove("X-AspNetMvc-Version");
    await next();
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.MapHealthChecks("/healthz");

app.MapGet(
    "/get-version",
    () =>
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        Process process = Process.GetCurrentProcess();
        return JsonConvert.SerializeObject(
            new
            {
                Version = fileVersionInfo.ProductVersion,
                MemoryUsage = FileSizeFormatter.FormatSize(
                    process.WorkingSet64
                        + process.PagedSystemMemorySize64
                        + GC.GetGCMemoryInfo().TotalCommittedBytes
                        + GC.GetTotalMemory(false)
                ),
            }
        );
    }
);

// Use CORS based on environment
app.UseCors(app.Environment.IsDevelopment() ? "AllowAllPolicy" : "RestrictedPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/swagger.css");
        options.InjectJavascript("/swagger-ui/jquery-3.7.1.min.js");
        options.InjectJavascript("/swagger-ui/swagger.js");
        options.EnableFilter();
        options.EnablePersistAuthorization();
        options.EnableValidator();
        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.ShowExtensions();
        options.DocumentTitle = "STATE JIT SSS API";
        options.DocExpansion(DocExpansion.None);
    });
}


app.UseStaticFiles();

app.UseDefaultFiles();

app.UseFileServer();

app.UseAuthentication();

app.UseAuthorization();

app.UseAuthTokenMiddleware();

app.MapControllers();

app.MapHubEndpoint<NotificationHub>("/notifications");

app.Run();
