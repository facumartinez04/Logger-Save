using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    internal interface ILoggerDAO
    {
        void Write(Log log);
        List<Log> ReadAll();
    }
}
