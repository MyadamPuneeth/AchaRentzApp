using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AchaRentzDAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext Context;

        public CarRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task AddCar(CarDetails car)
        {
            await Context.CarDetails.AddAsync(car);
        }

        public async Task DeleteCar(int id)
        {
            var car = await Context.CarDetails.SingleOrDefaultAsync(u => u.CarId == id);
            if (car != null)
            {
                Context.CarDetails.Remove(car);
            }
            
        }

        public async Task<IEnumerable<CarDetails>> FindCars(Func<CarDetails, bool> predicate)
        {
            return Context.CarDetails.Where(predicate).ToList();
        }

        public async Task<IEnumerable<CarDetails>> GetAllCars()
        {
            return Context.CarDetails.ToList();
        }

        public async Task<CarDetails> GetCarById(int id)
        {
            return await Context.CarDetails.SingleOrDefaultAsync(u => u.CarId == id);
        }

        public async Task SaveCarChanges()
        {
            Context.SaveChanges();
        }

        public async Task UpdateCar(CarDetails car)
        {
            var existingCar = Context.CarDetails.Find(car.CarId);
            if (existingCar != null)
            {
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Color = car.Color;
            }
            Context.CarDetails.
        }
    }

}
