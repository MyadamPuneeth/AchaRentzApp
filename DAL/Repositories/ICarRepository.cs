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
        Task<CarDetail> GetCarById(int id);
        Task <IEnumerable<CarDetail>> GetAllCars();
        Task AddCar(CarDetail car);
        //Task UpdateCar(CarDetail car);
        Task DeleteCar(int id);
        Task<IEnumerable<CarDetail>> FindCars(Func<CarDetail, bool> predicate);
        Task SaveCarChanges();
    }
}

