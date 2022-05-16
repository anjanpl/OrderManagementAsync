using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetSupplier(int Id);
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task<Supplier> Add(Supplier supplier);
        Task<Supplier> Update(Supplier supplierChanges);
        Task<Supplier> Delete(int id);
    }
}
