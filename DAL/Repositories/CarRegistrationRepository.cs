using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace AchaRentzDAL.Repositories
{
    public class CarRegistrationRepository : ICarRegistrationRepository
    {
        private readonly AppDbContext Context;

        public CarRegistrationRepository(AppDbContext context)
        {
            Context = context;
        }
        public async Task AddCar(CarDetail car)
        {
            Context.Add(car);
            await Context.SaveChangesAsync();
        }

        public async Task AddOwner(int userId, int carId)
        {
            var owner = new Owner { UserId = userId, CarId = carId };
            Context.Owners.Add(owner);
            await Context.SaveChangesAsync();
        }

        public async Task<CarDetail?> GetCarDetailsById(int id)
        {
            return await Context.CarDetail.SingleOrDefaultAsync(c => c.CarId == id);
        }

        public async Task UpdateCarDetails(CarDetail car)
        {
            Context.CarDetail.Update(car);
            await Context.SaveChangesAsync();
        }
    }
}
