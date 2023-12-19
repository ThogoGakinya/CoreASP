using CoreASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreASP.DataAccess.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public void Update(Product product);
    }
}
