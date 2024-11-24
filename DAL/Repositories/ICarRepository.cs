using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AchaRentzDAL.Repositories
{
    public interface ICarRepository
    {
        Task<CarDetails> GetCarById(int id);
        Task <IEnumerable<CarDetails>> GetAllCars();
        Task AddCar(CarDetails car);
        Task UpdateCar(CarDetails car);
        Task DeleteCar(int id);
        Task<IEnumerable<CarDetails>> FindCars(Func<CarDetails, bool> predicate);
        Task SaveCarChanges();
    }
}

