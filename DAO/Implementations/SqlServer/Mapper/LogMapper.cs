using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Log;

namespace DAO.Implementations.SqlServer.Mapper
{
    public sealed class LogMapper
    {

        
        #region singleton
            private readonly static LogMapper _instance = new LogMapper();

            public static LogMapper Current
            {
                get
                {
                    return _instance;
                }
            }

            private LogMapper()
            {
                //Implent here the initialization of your singleton
            }
            #endregion
       


        public Log Fill(object[] values)
        {
            return new Log()
            {
                Id = int.Parse(values[0].ToString()),
                message = Convert.ToString(values[1].ToString())
            };
        }

        internal enum CustomerColumns
        {
            Id = 0,
            Message = 1,
        }
    }
}
