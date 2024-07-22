using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log
    {
        public int Id { get; set; } 

        public string message { get; set; }

        public enum Serverity {
            LOW = 0,
            MEDIUM = 1,
            HIGH = 2,
        }
    }
}
