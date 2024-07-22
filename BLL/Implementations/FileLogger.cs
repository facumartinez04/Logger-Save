using BLL.Interfaces;
using DAO.Implementations.Memory;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementations
{
    public sealed class FileLogger : ILogger
    {

        
        #region singleton
            private readonly static FileLogger _instance = new FileLogger();

            public static FileLogger Current
            {
                get
                {
                    return _instance;
                }
            }

            private FileLogger()
            {
                //Implent here the initialization of your singleton
            }
            #endregion
     

        public List<Log> GetAll()
        {
            return FileLoggerDAO.Current.ReadAll();
        }

        public void Store(Log log)
        {
            Random rnd = new Random();
            log.Id = rnd.Next(1, 1000);
            FileLoggerDAO.Current.Write(log);
        }
    }
}
