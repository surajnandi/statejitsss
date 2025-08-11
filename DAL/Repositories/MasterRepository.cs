using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.SignalR;
using statejitsss.BAL.Interfaces;
using statejitsss.DAL.Entities;
using statejitsss.DAL.Enums;
using statejitsss.DAL.Interfaces;
using statejitsss.Helpers;

namespace statejitsss.DAL.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly StateJitDbContext _stateJitDbcontext;
        private readonly DapperContext _dapperContext;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;

        public MasterRepository(StateJitDbContext stateJitDbcontext, DapperContext dapperContext, IAuthService authService, IMapper mapper, IHubContext<NotificationHub> hubContext)
        {
            _stateJitDbcontext = stateJitDbcontext;
            _dapperContext = dapperContext;
            _authService = authService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public async Task<ServiceResponse<PagedResult<MmGenDdo>>> GetAllDdos(DapperQueryParameter parameters)
        {
            try
            {
                using var connection = _dapperContext.CreateConnection();

                var result = DapperQueryHelper.GetPagedData<MmGenDdo>(
                    connection,
                    "ifmsadmin.mm_gen_ddo",
                    parameters);

                return new ServiceResponse<PagedResult<MmGenDdo>>
                {
                    Result = result,
                    ResponseStatus = result.Data.Any() ? ResponseStatus.Success : ResponseStatus.Warning,
                    Message = result.Data.Any() ? AppConstants.DataFound : AppConstants.DataNotFound
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<PagedResult<MmGenDdo>>
                {
                    Result = null,
                    ResponseStatus = ResponseStatus.Error,
                    Message = ex.Message
                };
            }
        }


        public async Task<ServiceResponse<IEnumerable<MmGenDdo>>> GetDdoDetails()
        {
            try
            {
                const string query = "SELECT * FROM ifmsadmin.mm_gen_ddo WHERE ddo_code = @DdoCode";

                using var connection = _dapperContext.CreateConnection();
                //var ddos = await connection.QueryAsync<MmGenDdo>(query);
                var ddos = await connection.QueryAsync<MmGenDdo>(query, new { DdoCode = _authService.User.Scope });

                var ddoList = ddos.ToList();

                if (!ddoList.Any())
                {
                    return new ServiceResponse<IEnumerable<MmGenDdo>>
                    {
                        Result = ddoList,
                        ResponseStatus = ResponseStatus.Warning,
                        Message = AppConstants.DataNotFound
                    };
                }

                //await NotificationHelper.SendMessageToAll(_hubContext,"Testing");

                return new ServiceResponse<IEnumerable<MmGenDdo>>
                {
                    Result = ddoList,
                    ResponseStatus = ResponseStatus.Success,
                    Message = AppConstants.DataFound
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<MmGenDdo>>
                {
                    Result = null,
                    ResponseStatus = ResponseStatus.Error,
                    Message = ex.Message
                };
            }


        }
    }
}
