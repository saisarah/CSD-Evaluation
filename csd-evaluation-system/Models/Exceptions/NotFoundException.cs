using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csd_evaluation_system.Models.Exceptions
{
    class NotFoundException : Exception
    {
        public NotFoundException(string query) : base("Not found: " + query)
        {

        }
    }
}
