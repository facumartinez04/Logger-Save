using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class CriticalException : Exception

    {

        public CriticalException(string message)
          : base(message)
        {

            EmailService.Current.EnviarCorreo("soporteNivel1@email.com", message);
    
        }
    }
}
