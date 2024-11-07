using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using AchaRentzBLL.DTO;
using Newtonsoft.Json;
using AchaRentzBLL.Interfaces.ReusableLogics;

namespace PresentationLayer.Controllers
{
    public class CarRegisterController : Controller
    {
        private readonly CarRegistrationService CarService;
        private readonly ReusableCodeSnippets Reuser;
        public CarRegisterController(CarRegistrationService carService, ReusableCodeSnippets reuser)
        {
            CarService = carService;
            Reuser = reuser;
        }

        [HttpGet]
        public IActionResult RegisterACarPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterACarPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                TempData["CarDto"] = JsonConvert.SerializeObject(carDto);
                TempData.Keep("CarDto");

                return RedirectToAction("CarBasicDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public async Task<IActionResult> CarBasicDetailsPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto"); // Keep TempData for next requests

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult CarBasicDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                TempDataStorage(carDto);
                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult CarTechnicalDetailsPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto");

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult CarTechnicalDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                // Retrieve existing CarDto from TempData
                TempDataStorage(carDto);

                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult RentalInformationPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto");

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult RentalInformationPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                // Retrieve existing CarDto from TempData
                TempDataStorage(carDto);

                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult AdditionalRentalDetailsPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto");

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult AdditionalRentalDetailsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                // Retrieve existing CarDto from TempData
                TempDataStorage(carDto);

                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult CarFeaturesPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto");

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult CarFeaturesPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                TempDataStorage(carDto);

                return RedirectToAction("CarTechnicalDetailsPage");
            }
            return View(carDto);
        }

        [HttpGet]
        public IActionResult ExteriorSpecificationsPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                TempData.Keep("CarDto");

                return View(carDto);
            }

            return RedirectToAction("ErrorPage");
        }

        [HttpPost]
        public IActionResult ExteriorSpecificationsPage(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                TempDataStorage(carDto);
                // Complete the process and redirect to the success page
                return RedirectToAction("CarRegistrationSuccessPage");
            }
            return View(carDto);
        }

        public IActionResult CarRegistrationSuccessPage()
        {
            if (TempData["CarDto"] is string carDtoJson)
            {
                var carDto = JsonConvert.DeserializeObject<CarDto>(carDtoJson);
                CarService.AddCarAsync(carDto);
                return View(carDto); // Display success message with CarDto details if needed
            }

            return RedirectToAction("ErrorPage");
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public void TempDataStorage(CarDto entity)
        {
            // Retrieve existing CarDto from TempData
            var existingDto = JsonConvert.DeserializeObject(TempData["CarDto"] as string);

            // Call the service method to update fields
            Reuser.SaveDataTemp(existingDto, entity);

            // Save the updated DTO back to TempData
            TempData["Dto"] = JsonConvert.SerializeObject(existingDto);
            TempData.Keep("Dto");
        }

    }
}
