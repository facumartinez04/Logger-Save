using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class EmailService
    {


		#region singleton
			private readonly static EmailService _instance = new EmailService();

			public static EmailService Current
			{
				get
				{
					return _instance;
				}
			}

			private EmailService()
			{
				//Implent here the initialization of your singleton
			}
			#endregion
		


		public void EnviarCorreo(string correo, string message)
        {

        }
    }
}
