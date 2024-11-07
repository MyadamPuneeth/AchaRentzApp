using AchaRentzBLL.DTO;
using DAL.Models;

namespace AchaRentzBLL.Interfaces
{
    public interface ICarRegistrationInterface
    {
        public Task<CarDetail?> GetCarDetailsByIdAsync(int id);
        public Task AddCarAsync(CarDto car);
        public Task UpdateCarDetailsAsync(CarDto car);
        public Task AddOwnerAsync(int userId, int carId);
    }
}
