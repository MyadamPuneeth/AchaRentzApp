using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaRentzDAL.Repositories
{
    public interface ICarRegistrationRepository
    {
        public Task<CarDetail?> GetCarDetailsById(int id);
        public Task AddCar(CarDetail car);
        public Task UpdateCarDetails(CarDetail car);
        public Task AddOwner(int userId, int carId);
    }
}
