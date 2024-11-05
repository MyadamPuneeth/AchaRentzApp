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

        public async Task<CarDetail?> GetCarDetailsByIdAsync(int id)
        {
            return await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
        }

        public async Task AddCarAsync(CarDetail car)
        {
            Context.CarDetail.Add(car);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateCarDetailsAsync(CarDetail car)
        {
            Context.CarDetail.Update(car);
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
