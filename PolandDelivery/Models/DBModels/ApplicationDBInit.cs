using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PolandDelivery.Models.DBModels
{
    public class ApplicationDBInit
    {
        private readonly ApplicationContext _databaseContext;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly ILogger<ApplicationDBInit> _logger;

        public ApplicationDBInit(ApplicationContext databaseContext, IOptions<AppSettings> appSettings, ILogger<ApplicationDBInit> logger)
        {
            _databaseContext = databaseContext;
            _appSettings = appSettings;
            _logger = logger;
        }

        public void Init()
        {
            try
            {
                int menuCnt = _databaseContext.Menus.Count();
                if (menuCnt == 0)
                {
                    InsertBaseRecords();
                    UpdateAppSetting("InitDB", "true");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("DB Initalization error: " + ex.Message);
            }
        }

        void UpdateAppSetting(string key, string value)
        {
            var configJson = File.ReadAllText("appsettings.json");
            var config = JsonSerializer.Deserialize<Dictionary<string, object>>(configJson);
            config[key] = value;
            var updatedConfigJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("appsettings.json", updatedConfigJson);
        }

        void InsertBaseRecords()
        {
            FileInfo file = new FileInfo("polanddb.sql");
            string script = file.OpenText().ReadToEnd();
            script = script.Replace("GO", "");

            SqlConnection tmpConn;
            tmpConn = new SqlConnection();
            tmpConn.ConnectionString = _appSettings.Value.connectionString;
            tmpConn.Open();
            SqlCommand myCommandnew = new SqlCommand(script, tmpConn);
            var resultnew = myCommandnew.ExecuteNonQuery();
            Console.WriteLine(resultnew);
            tmpConn.Close();
        }
    }
}
