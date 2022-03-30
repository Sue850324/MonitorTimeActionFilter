using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;
using BaseLibrary.Model;

namespace BaseLibrary.Repository
{
    class CreateLogReposiory
    {
        public void Create(LogModel model)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["LogDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                string strSql = @"INSERT INTO LogFile
                                (Id, Mode, Context, CreateDate)
                                 VALUES
                                 (NewID(), @Mode, @Context, GETUTCDATE())";

                conn.Execute(strSql, model);
            }
        }
    }
}
