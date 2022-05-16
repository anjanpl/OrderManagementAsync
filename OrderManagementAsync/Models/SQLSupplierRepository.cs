using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class SQLSupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext context;

        public SQLSupplierRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Supplier> Add (Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> Delete(int id)
        {
            Supplier supplier = await context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                context.Suppliers.Remove(supplier);
                await context.SaveChangesAsync();
            }
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            return await context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplier(int Id)
        {
            return await context.Suppliers.FindAsync(Id);
        }

        public async Task<Supplier> Update(Supplier supplierChanges)
        {
            var supplier = context.Suppliers.Attach(supplierChanges);
            supplier.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return supplierChanges;
        }

       
    }
}
