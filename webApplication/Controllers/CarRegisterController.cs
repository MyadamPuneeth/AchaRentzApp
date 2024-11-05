using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Models;
using PresentationLayer.ViewModels;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Controllers
{
    public class CarRegisterController : Controller
    {
        private readonly CarService CarService;
        private readonly AppDbContext Context;

        public CarRegisterController(CarService carService, AppDbContext context)
        {
            CarService = carService;
            Context = context;
        }

        [HttpGet]
        public IActionResult RegisterACarPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterACarPage(CarDetail carModel)
        {
            if (ModelState.IsValid)
            {
                await CarService.AddCarAsync(carModel);
                HttpContext.Session.SetInt32("CarId", carModel.CarId);
                return RedirectToAction("CarBasicDetailsPage", new { id = carModel.CarId });
            }
            return View(carModel);
        }

        [HttpGet]
        public async Task<IActionResult> CarBasicDetailsPage(int id)
        {
            var car = await CarService.GetCarDetailsByIdAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }

        

        [HttpPost]
        public async Task<IActionResult> CarBasicDetailsPage(int id, CarBasicDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var car = await CarService.GetCarDetailsByIdAsync(id);
                if (car != null)
                {
                    car.RcNumber = model.RcNumber ?? 0;
                    car.InsuranceNumber = model.InsuranceNumber ?? 0;
                    car.LicensePlate = model.LicensePlate;
                    car.Mileage = model.Mileage;
                    car.Year = model.Year;

                    await CarService.UpdateCarDetailsAsync(car);
                    return RedirectToAction("CarTechnicalDetailsPage", new { id = car.CarId });
                }
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CarTechnicalDetailsPage(int id)
        {
            var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarTechnicalDetailsPage(int id, CarDetail carTechnicalModel)
        {
            if (ModelState.IsValid)
            {
                var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.FuelType = carTechnicalModel.FuelType;
                    user.Mileage = carTechnicalModel.Mileage;
                    user.Transmission = carTechnicalModel.Transmission;
                    user.FuelCapacity = carTechnicalModel.FuelCapacity;

                    Context.SaveChanges();

                    return RedirectToAction("RentalInformationPage", new { id = user.CarId });
                }
                else
                {
                    return NotFound(); // Return 404 if the user was not found
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RentalInformationPage(int id)
        {
            var car = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> RentalInformationPage(int id, CarDetail rentalInfoModel)
        {
            if (ModelState.IsValid)
            {
                var car = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
                if (car != null)
                {
                    car.RentalPricePerDay = rentalInfoModel.RentalPricePerDay;
                    car.IsAvailable = rentalInfoModel.IsAvailable;
                    car.RentalLocation = rentalInfoModel.RentalLocation;
                    car.AvailableFrom = rentalInfoModel.AvailableFrom;
                    car.AvailableUntil = rentalInfoModel.AvailableUntil;
                    car.MinimumRentalPeriod = rentalInfoModel.MinimumRentalPeriod;
                    car.HomeDeliveryAvailable = rentalInfoModel.HomeDeliveryAvailable;

                    await Context.SaveChangesAsync();
                    return RedirectToAction("AdditionalRentalDetailsPage", new { id = car.CarId });
                }
                else
                {
                    return NotFound();
                }
            }
            return View(rentalInfoModel);
        }

        [HttpGet]
        public async Task<IActionResult> AdditionalRentalDetailsPage(int id)
        {
            var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AdditionalRentalDetailsPage(int id, CarDetail additionalDetailsModel)
        {
            if (ModelState.IsValid)
            {
                var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.DistanceFromUser = additionalDetailsModel.DistanceFromUser;
                    user.UserRating = additionalDetailsModel.UserRating;
                    user.Notes = additionalDetailsModel.Notes;

                    await Context.SaveChangesAsync();
                    return RedirectToAction("CarFeaturesPage", new { id = user.CarId });
                }
                else
                {
                    return NotFound();
                }
            }
            return View(additionalDetailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> CarFeaturesPage(int id)
        {
            var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarFeaturesPage(int id, CarDetail featuresModel)
        {
            if (ModelState.IsValid)
            {
                var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.HasAirConditioning = featuresModel.HasAirConditioning;
                    user.HasGPS = featuresModel.HasGPS;
                    user.HasBluetooth = featuresModel.HasBluetooth;
                    user.HasBackupCamera = featuresModel.HasBackupCamera;
                    user.HasChildSeat = featuresModel.HasChildSeat;
                    user.HasHeatedSeats = featuresModel.HasHeatedSeats;

                    await Context.SaveChangesAsync();
                    return RedirectToAction("ExteriorSpecificationsPage", new { id = user.CarId });
                }
                else
                {
                    return NotFound();
                }
            }
            return View(featuresModel);
        }

        [HttpGet]
        public async Task<IActionResult> ExteriorSpecificationsPage(int id)
        {
            var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ExteriorSpecificationsPage(int id, CarDetail exteriorModel)
        {
            if (ModelState.IsValid)
            {
                var user = await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.Color = exteriorModel.Color;
                    user.Length = exteriorModel.Length;
                    user.Width = exteriorModel.Width;
                    user.Height = exteriorModel.Height;
                    user.SeatingCapacity = exteriorModel.SeatingCapacity;
                    user.NumberOfDoors = exteriorModel.NumberOfDoors;

                    await Context.SaveChangesAsync();
                    return RedirectToAction("CarRegistrationSuccessPage");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(exteriorModel);
        }

        public IActionResult CarRegistrationSuccessPage()
        {
            return View();
        }

    }

}
