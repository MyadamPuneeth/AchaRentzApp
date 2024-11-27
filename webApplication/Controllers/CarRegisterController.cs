using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using AchaRentzBLL.DTO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class CarRegisterController : Controller
    {
        private readonly CarRegistrationService CarService;

        public CarRegisterController(CarRegistrationService carService)
        {
            CarService = carService;
        }

        private void SaveCarDtoToTempData(CarDto carDto)
        {
            TempData["CarDto"] = JsonConvert.SerializeObject(carDto);
            TempData.Keep("CarDto"); // Ensures TempData persists to the next request
        }

        private CarDto GetCarDtoFromTempData()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto"); // Keep TempData alive for the next request
                return carDto;
            }
            return new CarDto();
        }

        private void UpdateCarDto(CarDto existingCarDto, CarDto newCarDto)
        {
            // Copy properties from newCarDto to existingCarDto if they are not null or empty
            foreach (var property in typeof(CarDto).GetProperties())
            {
                var newValue = property.GetValue(newCarDto);
                if (newValue != null)
                {
                    property.SetValue(existingCarDto, newValue);
                }
            }
        }


        [HttpGet]
        public IActionResult RegisterACarPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterACarPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                SaveCarDtoToTempData(carDto);
                return RedirectToAction("CarBasicDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult CarBasicDetailsPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public IActionResult CarBasicDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto);
                SaveCarDtoToTempData(existingCarDto);
                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult CarTechnicalDetailsPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public IActionResult CarTechnicalDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto); 
                SaveCarDtoToTempData(existingCarDto);
                return RedirectToAction("RentalInformationPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult RentalInformationPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public IActionResult RentalInformationPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto);
                SaveCarDtoToTempData(existingCarDto);
                return RedirectToAction("AdditionalRentalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult AdditionalRentalDetailsPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public IActionResult AdditionalRentalDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto);
                SaveCarDtoToTempData(existingCarDto);
                return RedirectToAction("CarFeaturesPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult CarFeaturesPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public IActionResult CarFeaturesPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto);
                SaveCarDtoToTempData(existingCarDto);
                return RedirectToAction("ExteriorSpecificationsPage");
            }
            return View(carDto);
        }


        [HttpGet]
        public IActionResult ExteriorSpecificationsPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> ExteriorSpecificationsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var existingCarDto = GetCarDtoFromTempData();
                UpdateCarDto(existingCarDto, carDto);
                SaveCarDtoToTempData(existingCarDto);
                carDto = GetCarDtoFromTempData();
                await CarService.AddCarAsync(carDto);
                return RedirectToAction("CarRegistrationSuccessPage");
            }
            return View(carDto);
        }

        public IActionResult CarRegistrationSuccessPage()
        {
            var carDto = GetCarDtoFromTempData();
            return View(carDto);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
