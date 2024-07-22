using BLL.Interfaces;
using DAO.Implementations.SqlServer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementations
{
    public sealed class SqlLogger : ILogger
    {


       
        #region singleton
            private readonly static SqlLogger _instance = new SqlLogger();

            public static SqlLogger Current
            {
                get
                {
                    return _instance;
                }
            }

            private SqlLogger()
            {
                //Implent here the initialization of your singleton
            }
            #endregion
        


        public List<Log> GetAll()
        {
           return SqlLoggerDAO.Current.ReadAll();
        }

        public void Store(Log log)
        {
            SqlLoggerDAO.Current.Write(log);
            
        }
    }
}
