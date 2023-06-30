using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCS.DataAccess.Models;

namespace TCCS.UnitTesting.Core.MoqData
{
    public class EmployeeMoq : IClassFixture<TCCSDataFixture>
    {
        TCCSDataFixture fixture;

        public EmployeeMoq(TCCSDataFixture fixture)
        {
            this.fixture = fixture;
        }
        public void MoqData(Employee entity)
        {
            using (var qssContext = new TccsContext(fixture.tccsContextOptions))
            {
                qssContext.Employees.Add(entity);
                qssContext.SaveChanges();
            }
        }

        public void MoqDataList(IEnumerable<Employee> entityList)
        {
            using (var qssContext = new TccsContext(fixture.tccsContextOptions))
            {
                qssContext.Employees.AddRangeAsync(entityList);
                qssContext.SaveChanges();
            }
        }

        public List<Employee> GetMoqDataList()
        {
            using (var qssContext = new TccsContext(fixture.tccsContextOptions))
            {
                var res = qssContext.Employees.ToList();
                return res;
            }
        }
    }
}
