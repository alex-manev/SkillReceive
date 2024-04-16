using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Exceptions
{
    public class NotAmemberException : Exception
    {
        public NotAmemberException()
        {
            
        }

        public NotAmemberException(string message) : base(message) 
        {
            
        }

    }
}
