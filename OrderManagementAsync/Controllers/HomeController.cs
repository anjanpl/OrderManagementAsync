using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using OrderManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public HomeController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _supplierRepository.GetAllSupplier();
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            int supplierId = Convert.ToInt32(id);

            Supplier supplier = await _supplierRepository.GetSupplier(supplierId);

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Supplier = supplier,
                PageTitle = "Supplier Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Supplier newSupplier = new Supplier
                {
                    Name = model.Name,
                    AddresslineOne = model.AddresslineOne,
                    AddresslineTwo = model.AddresslineTwo,  
                    City = model.City,
                    PostalCode = model.PostalCode,
                    State = model.State
                };

                await _supplierRepository.Add(newSupplier);
                return RedirectToAction("details", new { id = newSupplier.Id });
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Supplier supplier = await _supplierRepository.GetSupplier(id);
            SupplierEditViewModel supplierEditViewModel = new SupplierEditViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                AddresslineOne = supplier.AddresslineOne,
                AddresslineTwo = supplier.AddresslineTwo,
                City = supplier.City,
                PostalCode = supplier.PostalCode,
                State = supplier.State
        };
            return View(supplierEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplierEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = await _supplierRepository.GetSupplier(model.Id);

                supplier.Name = model.Name;
                supplier.AddresslineOne = model.AddresslineOne;
                supplier.AddresslineTwo = model.AddresslineTwo;
                supplier.City = model.City;
                supplier.PostalCode = model.PostalCode;
                supplier.State = model.State;

                await _supplierRepository.Update(supplier);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var supplierToDelete = await _supplierRepository.GetSupplier(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Supplier with Id = {id} not found");
                }

                await _supplierRepository.Delete(supplierToDelete.Id);

                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
