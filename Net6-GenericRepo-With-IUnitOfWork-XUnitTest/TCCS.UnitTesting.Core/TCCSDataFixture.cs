using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.UnitTesting.Core
{
    public class TCCSDataFixture : IDisposable
    {
        public TccsContext tccsContext { get; private set; }
        public DbContextOptions<TccsContext> tccsContextOptions { get; private set; }
        private const string Database = "TCCSInMemoryDatabase";


        public TCCSDataFixture()
        {

            tccsContextOptions = new DbContextOptionsBuilder<TccsContext>()
                .UseInMemoryDatabase(Database + DateTime.Now.ToFileTimeUtc())

             //.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                //.EnableSensitiveDataLogging(true)
                .Options;


            tccsContext = new TccsContext(tccsContextOptions);
            tccsContext.Database.EnsureDeleted();
            tccsContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            tccsContext.Database.EnsureDeleted();
            tccsContext.Dispose();
        }
    }
}
