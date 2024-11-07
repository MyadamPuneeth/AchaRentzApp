using DAL.Models;
using AchaRentzBLL.Interfaces;
using AchaRentzDAL.Repositories;
using AchaRentzBLL.DTO;
using Microsoft.AspNetCore.Components.Routing;

namespace BLL.Services
{
    public class CarRegistrationService : ICarRegistrationInterface
    {
        private readonly CarRegistrationRepository CarRepo;

        public CarRegistrationService(CarRegistrationRepository carRepo)
        {
            CarRepo = carRepo;
        }

        public async Task<CarDetail?> GetCarDetailsByIdAsync(int id)
        {
            return await CarRepo.GetCarDetailsById(id);
        }

        public async Task AddCarAsync(CarDto carDto)
        {
            var car = new CarDetail();

            foreach (var property in typeof(CarDto).GetProperties())
            {
                var targetProperty = typeof(CarDetail).GetProperty(property.Name);
                if (targetProperty != null)
                {
                    targetProperty.SetValue(car, property.GetValue(carDto));
                }
            }
            await CarRepo.AddCar(car);
        }

        public async Task UpdateCarDetailsAsync(CarDto carDto)
        {
            var car = new CarDetail();

            foreach (var property in typeof(CarDto).GetProperties())
            {
                var targetProperty = typeof(CarDetail).GetProperty(property.Name);
                if (targetProperty != null)
                {
                    targetProperty.SetValue(car, property.GetValue(carDto));
                }
            }
            await CarRepo.UpdateCarDetails(car);
        }

        public async Task AddOwnerAsync(int userId, int carId)
        {
            await CarRepo.AddOwner(userId, carId);
        }
    }
}
