using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Data
{
    public class DataContextConfiguration
    {
        private readonly DataContext _context;

        public DataContextConfiguration(DataContext context)
        {
            _context = context;
        }
    }
}
