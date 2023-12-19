﻿using CoreASP.DataAccess.Data;
using CoreASP.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreASP.DataAccess.Repository
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }
        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
