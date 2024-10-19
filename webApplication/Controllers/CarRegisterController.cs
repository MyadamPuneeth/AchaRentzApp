using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplication.Models;

namespace webApplication.Controllers
{
    public class CarRegisterController : Controller
    {
        private readonly AppDbContext _context;

        public CarRegisterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegisterACarPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterACarPage(CarDetails carModel)
        {
            
            if (ModelState.IsValid)
            { 
                _context.CarDetails.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("CarBasicDetailsPage", new { id = carModel.CarId});
            }
            return View(carModel);
        }

        [HttpGet]
        public async Task<IActionResult> CarBasicDetailsPage(int id)
        {
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarBasicDetailsPage(int id, CarDetails carBasicModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.RcNumber = carBasicModel.RcNumber;
                    user.InsuranceNumber = carBasicModel.InsuranceNumber;
                    user.LicensePlate = carBasicModel.LicensePlate;
                    user.Mileage = carBasicModel.Mileage;
                    user.Year = carBasicModel.Year;

                    _context.SaveChanges();
                    return RedirectToAction("CarTechnicalDetailsPage", new {id = user.CarId});
                }
                else
                {
                    return NotFound(); // Return 404 if the user was not found
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CarTechnicalDetailsPage(int id)
        {
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarTechnicalDetailsPage(int id, CarDetails carTechnicalModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.FuelType = carTechnicalModel.FuelType;
                    user.Mileage = carTechnicalModel.Mileage;
                    user.Transmission = carTechnicalModel.Transmission;
                    user.FuelCapacity = carTechnicalModel.FuelCapacity;
                    
                    _context.SaveChanges();

                    return RedirectToAction("RentalInformationPage", new {id = carTechnicalModel.CarId});
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
            var car = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> RentalInformationPage(int id, CarDetails rentalInfoModel)
        {
            if (ModelState.IsValid)
            {
                var car = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (car != null)
                {
                    car.RentalPricePerDay = rentalInfoModel.RentalPricePerDay;
                    car.IsAvailable = rentalInfoModel.IsAvailable;
                    car.RentalLocation = rentalInfoModel.RentalLocation;
                    car.AvailableFrom = rentalInfoModel.AvailableFrom;
                    car.AvailableUntil = rentalInfoModel.AvailableUntil;
                    car.MinimumRentalPeriod = rentalInfoModel.MinimumRentalPeriod;
                    car.HomeDeliveryAvailable = rentalInfoModel.HomeDeliveryAvailable;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("AdditionalRentalDetailsPage", new { id = rentalInfoModel.CarId });
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
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AdditionalRentalDetailsPage(int id, CarDetails additionalDetailsModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.DistanceFromUser = additionalDetailsModel.DistanceFromUser;
                    user.UserRating = additionalDetailsModel.UserRating;
                    user.Notes = additionalDetailsModel.Notes;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("CarFeaturesPage", new { id = additionalDetailsModel.CarId });
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
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarFeaturesPage(int id, CarDetails featuresModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.HasAirConditioning = featuresModel.HasAirConditioning;
                    user.HasGPS = featuresModel.HasGPS;
                    user.HasBluetooth = featuresModel.HasBluetooth;
                    user.HasBackupCamera = featuresModel.HasBackupCamera;
                    user.HasChildSeat = featuresModel.HasChildSeat;
                    user.HasHeatedSeats = featuresModel.HasHeatedSeats;
                    user.HasMileageLimit = featuresModel.HasMileageLimit;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("ExteriorSpecificationsPage", new { id = featuresModel.CarId });
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
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ExteriorSpecificationsPage(int id, CarDetails exteriorModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.Color = exteriorModel.Color;
                    user.Length = exteriorModel.Length;
                    user.Width = exteriorModel.Width;
                    user.Height = exteriorModel.Height;
                    user.SeatingCapacity = exteriorModel.SeatingCapacity;
                    user.NumberOfDoors = exteriorModel.NumberOfDoors;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("InsuranceInformationPage", new { id = exteriorModel.CarId });
                }
                else
                {
                    return NotFound();
                }
            }
            return View(exteriorModel);
        }

        [HttpGet]
        public async Task<IActionResult> InsuranceInformationPage(int id)
        {
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> InsuranceInformationPage(int id, CarDetails insuranceModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.InsuranceIncluded = insuranceModel.InsuranceIncluded;
                    user.InsuranceExpiryDate = insuranceModel.InsuranceExpiryDate;
                    user.InsuranceProvider = insuranceModel.InsuranceProvider;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(insuranceModel);
        }


    }

}
