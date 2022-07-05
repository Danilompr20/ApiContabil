using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Refresh
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
