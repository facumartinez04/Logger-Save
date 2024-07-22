using DAO.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementations.Memory
{
    public sealed class FileLoggerDAO : ILoggerDAO
    {

        #region singleton
            private readonly static FileLoggerDAO _instance = new FileLoggerDAO();

            public static FileLoggerDAO Current
            {
                get
                {
                    return _instance;
                }
            }

            private FileLoggerDAO()
            {
                //Implent here the initialization of your singleton
            }
            #endregion
       
        

        public List<Log> ReadAll()
        {

            using (StreamReader readtext = new StreamReader(ConfigurationManager.AppSettings["PathLog"]))
            {
                List<Log> list = new List<Log>();  
                while(!readtext.EndOfStream)
                {
                    var split = readtext.ReadLine().Split(',');
                    list.Add(new Log { 
                        Id = Convert.ToInt32(split[0]),
                        message = Convert.ToString(split[1])   
                    });

                }

                return list;
                
            }
        }

        public void Write(Log log)
        {

            using (StreamWriter writetext = new StreamWriter(ConfigurationManager.AppSettings["PathLog"], true))
            {
                writetext.WriteLine($"{log.Id},{log.message}");
            }
        }
    }
}
