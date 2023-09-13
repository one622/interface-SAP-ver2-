using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Configuration
{
    public class ConnectionStrings
    {
        public const string Section = "ConnectionStrings";
        public string DefaultConnection { get; set; }
        public string PostgreSQLConnectiondb { get; set; }
     
    }
}
