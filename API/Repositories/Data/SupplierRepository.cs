using API.Context;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class SupplierRepository : GenericRepository<Supplier>
    {
        MyContext myContext;

        public SupplierRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public List<Supplier> Get()
        {
            var data = myContext.Supplier.ToList();
            return data;
        }
    }
}
