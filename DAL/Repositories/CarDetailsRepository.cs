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

        public async Task AddCar(CarDetail car)
        {
            await Context.CarDetail.AddAsync(car);
        }

        public async Task DeleteCar(int id)
        {
            var car = await Context.CarDetail.SingleOrDefaultAsync(u => u.CarId == id);
            if (car != null)
            {
                Context.CarDetail.Remove(car);
            }

        }

        public async Task<IEnumerable<CarDetail>> FindCars(Func<CarDetail, bool> predicate)
        {
            return Context.CarDetail.Where(predicate).ToList();
        }

        public async Task<IEnumerable<CarDetail>> GetAllCars()
        {
            return Context.CarDetail.ToList();
        }

        public async Task<CarDetail> GetCarById(int id)
        {
            return await Context.CarDetail.SingleOrDefaultAsync(u => u.CarId == id);
        }

        public async Task SaveCarChanges()
        {
            Context.SaveChanges();
        }

        public async Task UpdateCar(CarDetail car)
        {
            var existingCar = Context.CarDetail.Find(car.CarId);
            if (existingCar != null)
            {
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Color = car.Color;
            }
            Context.CarDetail.Update(car);
        }
    }

}
