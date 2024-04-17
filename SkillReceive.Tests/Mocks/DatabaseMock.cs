using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Tests.Mocks
{
    public class DatabaseMock
    {
        public static SkillReceiveDbContext Instance 
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<SkillReceiveDbContext>()
                    .UseInMemoryDatabase("SkillReceiveInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new SkillReceiveDbContext(dbContextOptions, false);
            }
        }
    }
}
