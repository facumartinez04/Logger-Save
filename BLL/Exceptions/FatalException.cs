using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class FatalException : Exception
    {

        public FatalException(string message)
          : base(message)
        {

            EmailService.Current.EnviarCorreo("soporteNivel2@email.com", message);
        }
    }
}
