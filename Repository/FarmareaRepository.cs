using BookListRazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using Npgsql;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using BookListRazor.Configuration;

using Dapper;

namespace BookListRazor.Repository
{
    public class FarmareaRepository : IFarmareaRepository
    {

        //private IDbConnection db;
        //public FarmareaRepository(IConfiguration configuration)
        //{
        //    this.db = new SqlConnection(configuration.GetConnectionString("CompanyConnection"));
        //}

        private readonly IConfiguration _configuration;
        private readonly AppSetting _appsetting;

        private readonly IHttpContextAccessor _httpContextAccessor;

     

        private string connectionString;
    
        private ConnectionStrings _connections;
        public FarmareaRepository(IConfiguration configuration,
            IOptions<ConnectionStrings> connections)
        {
            _connections = connections.Value;
            //connectionString = _connections.PostgreSQLConnectiondb;
            connectionString = "Server=10.4.89.188;Port=5432;User Id=postgres;Password= Crist@ll@prog!@#;Database=sugarcanedb";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }


        public List<Farmarea> LoadFarmarea()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                //var data = dbConnection.Query<Farmarea>($@"select * from farmarea f where dataareaid ='104' and crop_year ='66/67' and my_location_name ='10814-02')";

                var data = dbConnection.Query<Farmarea>($@"
                            select * from farmarea f where dataareaid ='104' and farmer_code  ='10814'");

                return data.ToList();
              
            }

        }


        //public async Task<(bool, DataTable, string)> ExecuteCommandReader(string commands)
        //{
        //    var isSuccess = false;
        //    var list = new DataTable();
        //    var message = string.Empty;
        //    try
        //    {
        //        using (NpgsqlConnection conn = new NpgsqlConnection(_glDataConnectionString))
        //        {
        //            conn.Open();
        //            NpgsqlCommand cmd = new NpgsqlCommand(commands, conn);
        //            cmd.CommandTimeout = 300;
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                list.Load(reader);
        //            }
        //            isSuccess = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    var result = (isSuccess, list, message);
        //    return await Task.FromResult(result);
        //}
    }
}
