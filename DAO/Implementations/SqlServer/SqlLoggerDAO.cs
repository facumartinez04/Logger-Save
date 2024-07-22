
using DAO.Helpers;
using DAO.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Implementations.SqlServer.Mapper;

namespace DAO.Implementations.SqlServer
{
    public class SqlLoggerDAO : ILoggerDAO
    {

        #region singleton
            private readonly static SqlLoggerDAO _instance = new SqlLoggerDAO();

            public static SqlLoggerDAO Current
            {
                get
                {
                    return _instance;
                }
            }

            private SqlLoggerDAO()
            {
                //Implent here the initialization of your singleton
            }
        #endregion


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Log] ([Message]) VALUES (@Message)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[] SET () WHERE  = @";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[] WHERE  = @";
        }

        private string SelectOneStatement
        {
            get => "SELECT ,  FROM [dbo].[] WHERE  = @";
        }

        private string SelectAllStatement
        {
            get => "SELECT *  FROM [dbo].[Log]";
        }
        #endregion



        public List<Log> ReadAll()
        {
            List<Log> list = new List<Log>();

            using (var reader = SqlHelper.ExecuteReader(SelectAllStatement, CommandType.Text,
                new SqlParameter[] { }))
            {
                //Mientras tenga algo en mi tabla de Customers
                while (reader.Read())
                {

                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    Log log = LogMapper.Current.Fill(data);
                    list.Add(log);
                }
            }

            return list;
        }

        public void Write(Log log)
        {

            int num = SqlHelper.ExecuteNonQuery(InsertStatement, CommandType.Text,
                  new SqlParameter[] { new SqlParameter("@Message", log.message) });
            

        }

         
    }
}
