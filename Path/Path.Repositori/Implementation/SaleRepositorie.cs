using Path.Model;
using Path.Repositori.Dbcontext;
using Path.Repositori.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.Repositori.Implementation
{
    public class SaleRepositorie : GenericRepositorie<Sale>, ISaleRepositorie
    {
        private readonly PathContext _context;
        public SaleRepositorie(PathContext _context) : base(_context)
        {
            _context = _context;
        }

        public async Task<Sale> RegisterSale(Sale model)
        {
            Sale sale = new();
            //Transsactions
            using (var transaction = _context.Database.BeginTransaction()) {
                try
                {
                    foreach (SaleDetail sd in model.SaleDetails)
                    {
                        Product found_product = _context.Products.Where(p=> p.IdProduct==sd.Idproudct).First();
                        found_product.Stock=found_product.Stock-sd.Stock;
                        _context.Products.Update(found_product);
                    }
                    await _context.SaveChangesAsync();

                    await _context.Sales.AddAsync(model);
                    await _context.SaveChangesAsync();
                    sale = model;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return sale;
               
        }
    }
}
