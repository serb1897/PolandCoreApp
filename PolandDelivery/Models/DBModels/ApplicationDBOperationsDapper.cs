using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PolandDelivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Models.DBModels
{
    public class ApplicationDBOperationsDapper : IDBOperationRepository
    {
        private string _connectionSettings;
        private IOptions<AppSettings> _appSettings;

        public ApplicationDBOperationsDapper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            _connectionSettings = _appSettings.Value.connectionString;
        }

        public string Execute(string query, object parameters)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionSettings))
                {
                    db.Execute(query, parameters);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<T> Query<T>(string query, object parameters)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionSettings))
                {
                    List<T> result = db.Query<T>(query, parameters).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }
}
