using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using BookListRazor.Configuration;

namespace BookListRazor.Model
{
    public class DataService : IDataService
    {
        
        private readonly IConfiguration _configuration;
        private readonly AppSetting _appsetting;
     
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string _glDataConnectionString;
        private readonly string _userCode;

        public DataService(IConfiguration configuration,
            IOptions<AppSetting> setting,
            IHttpContextAccessor httpContextAccessor
        //GLDataContext dataContext
        )
        {
            _configuration = configuration;
            _appsetting = setting.Value;
            //_dataContext = dataContext;
            _glDataConnectionString = configuration.GetConnectionString("PostgreSQLConnectiondb");
            _httpContextAccessor = httpContextAccessor;
            var httpContext = httpContextAccessor.HttpContext;
            var user = httpContext != null ? httpContext.User : null;
         
        }

        public async Task<(bool, DataTable, string)> ExecuteCommandReader(string commands)
        {
            var isSuccess = false;
            var list = new DataTable();
            var message = string.Empty;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_glDataConnectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(commands, conn);
                    cmd.CommandTimeout = 300;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        list.Load(reader);
                    }
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
               
            }

            var result = (isSuccess, list, message);
            return await Task.FromResult(result);
        }

        public async Task<(bool, Int32, string)> ExecuteCommandNoneQuery(string commands)
        {
            var isSuccess = false;
            var rowsaffect = 0;
            var message = string.Empty;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_glDataConnectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(commands, conn);
                    cmd.CommandTimeout = 300;
                    rowsaffect = await cmd.ExecuteNonQueryAsync();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
             
            }

            var result = (isSuccess, rowsaffect, message);
            return await Task.FromResult(result);
        }

        public async Task<(bool, Object, string)> ExecuteCommandScalar(string commands)
        {
            var isSuccess = false;
            Object obj = null;
            var message = string.Empty;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_glDataConnectionString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(commands, conn);
                    cmd.CommandTimeout = 300;
                    obj = await cmd.ExecuteScalarAsync();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
            
            }

            var result = (isSuccess, obj, message);
            return await Task.FromResult(result);
        }
    }
}
