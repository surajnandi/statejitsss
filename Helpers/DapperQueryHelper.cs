using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Text.Json;
using System.Text;

namespace statejitsss.Helpers
{
    public static class DapperQueryHelper
    {
        public static PagedResult<T> GetPagedData<T>(
            IDbConnection connection,
            string tableName,
            DapperQueryParameter parameters)
        {
            var dynamicParams = new DynamicParameters();

            // ---------- Filters ----------
            string whereSql = parameters.Filters?.Count > 0
                ? "WHERE " + string.Join(" AND ", parameters.Filters.Select(f =>
                {
                    string p = $"@f_{f.Key}";
                    var value = GetValue(f.Value);
                    dynamicParams.Add(p, value);
                    var columnName = GetColumnName<T>(f.Key);
                    return $"{columnName} = {p}";
                }))
                : string.Empty;

            // ---------- Global Search ----------
            if (!string.IsNullOrWhiteSpace(parameters.GlobalSearch))
            {
                var cols = connection.Query<string>(
                    @"SELECT column_name 
              FROM information_schema.columns 
              WHERE table_schema = split_part(@tbl, '.', 1) 
                AND table_name = split_part(@tbl, '.', 2)",
                    new { tbl = tableName });

                var searchSql = string.Join(" OR ", cols.Select((c, i) =>
                {
                    string p = $"@s_{i}";
                    dynamicParams.Add(p, $"%{parameters.GlobalSearch}%");
                    return $"CAST({c} AS TEXT) ILIKE {p}";
                }));

                whereSql += (string.IsNullOrEmpty(whereSql) ? "WHERE " : " AND ") + $"({searchSql})";
            }

            // ---------- Sorting ----------
            string orderBySql = parameters.Sorts?.Count > 0
                ? "ORDER BY " + string.Join(", ", parameters.Sorts.Select(s =>
                {
                    var sortValue = GetValue(s.Value);
                    var columnName = GetColumnName<T>(s.Key);
                    return $"{columnName} {(sortValue?.ToString()?.Equals("DESC", StringComparison.OrdinalIgnoreCase) == true ? "DESC" : "ASC")}";
                }))
                : string.Empty;

            // ---------- Pagination ----------
            int offset = (parameters.PageNumber - 1) * parameters.PageSize;
            dynamicParams.Add("@offset", offset);
            dynamicParams.Add("@limit", parameters.PageSize);

            // ---------- SQL ----------
            string countSql = $"SELECT COUNT(*) FROM {tableName} {whereSql}";
            string dataSql = $"SELECT * FROM {tableName} {whereSql} {orderBySql} OFFSET @offset LIMIT @limit";

            // ---------- Query ----------
            long totalCount = connection.ExecuteScalar<long>(countSql, dynamicParams);
            var data = connection.Query<T>(dataSql, dynamicParams);

            return new PagedResult<T>
            {
                TotalCount = totalCount,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                Data = data
            };
        }

        // Get column name from property (works with both Entity and Model)
        private static string GetColumnName<T>(string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null)
            {
                // Try to get Column attribute (for Entity)
                var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
                if (columnAttr?.Name != null)
                    return columnAttr.Name;
            }

            // Fallback: Convert to snake_case (for Models)
            return ToSnakeCase(propertyName);
        }

        // Convert JsonElement to actual value
        private static object GetValue(object value)
        {
            if (value is JsonElement jsonElement)
            {
                return jsonElement.ValueKind switch
                {
                    JsonValueKind.String => jsonElement.GetString(),
                    JsonValueKind.Number => jsonElement.TryGetInt32(out int intValue) ? intValue : jsonElement.GetDouble(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    JsonValueKind.Null => null,
                    _ => jsonElement.ToString()
                };
            }
            return value;
        }

        // Convert PascalCase to snake_case
        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var result = new StringBuilder();
            result.Append(char.ToLower(input[0]));

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    result.Append('_');
                    result.Append(char.ToLower(input[i]));
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }
    }
}
