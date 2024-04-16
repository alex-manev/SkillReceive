using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Exceptions
{
    public class AlreadyJoinedActionException : Exception
    {
        public AlreadyJoinedActionException()
        {
                
        }

        public AlreadyJoinedActionException(string message) : base(message) 
        {
            
        }

    }

}
