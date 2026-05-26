using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class NumberSequence
    {
        private int _current;

        public NumberSequence(int start = 10)
        {
            _current = start;
        }

        public int Next()
        {
            var value = _current;
            _current += 5;

            return value;
        }
    }
}