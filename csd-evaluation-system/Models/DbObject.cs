using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csd_evaluation_system.Models
{
    public class DbObject : Dictionary<string, object>
    {
        public DbObject Push(string key, object value)
        {
            this.Add(key, value);
            return this;
        }
    }
}
