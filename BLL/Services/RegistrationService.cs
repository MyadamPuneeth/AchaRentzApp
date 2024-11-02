using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Data;

namespace BLL.Services
{
    public class CarService
    {
        private readonly AppDbContext Context;

        public CarService(AppDbContext context)
        {
            Context = context;
        }

        public async Task<CarDetails?> GetCarDetailsByIdAsync(int id)
        {
            return await Context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
        }

        public async Task AddCarAsync(CarDetails car)
        {
            Context.CarDetails.Add(car);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateCarDetailsAsync(CarDetails car)
        {
            Context.CarDetails.Update(car);
            await Context.SaveChangesAsync();
        }

        public async Task AddOwnerAsync(int userId, int carId)
        {
            var owner = new Owner { UserId = userId, CarId = carId };
            Context.Owners.Add(owner);
            await Context.SaveChangesAsync();
        }
    }
}
