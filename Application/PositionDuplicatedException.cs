using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PositionDuplicatedException:Exception
    {
        public PositionDuplicatedException(string message) : base(message)
        {
        }
    }
}
