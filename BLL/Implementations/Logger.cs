using BLL.Exceptions;
using BLL.Interfaces;
using DAO.Implementations.Memory;
using DAO.Implementations.SqlServer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Implementations
{
    public  class Logger
    {

        string tiponuevo;


        public Logger(Tipo tipo)
        {   


            if(tipo == Tipo.SQL)
            {
                this.tiponuevo = "SQL";
            }
            else
            {
                this.tiponuevo = "Memory";
            }

        }

        public void Write(string message) {

            if(message.Contains("CriticalError")) throw new CriticalException(message);
            if (message.Contains("FatalError")) throw new FatalException(message);


            if (tiponuevo == "SQL")
            {
                SqlLogger.Current.Store(new Log { message = message });
            }
            else
            {
                FileLogger.Current.Store(new Log { message = message });

            }


        }

        public List<Log> ReadAll()
        {

            if (tiponuevo == "SQL")
            {
                return SqlLogger.Current.GetAll();
            }
            else
            {
                return FileLogger.Current.GetAll();

            }
        }

        public enum Tipo
        {
            File,
            SQL
        }
    }

}


