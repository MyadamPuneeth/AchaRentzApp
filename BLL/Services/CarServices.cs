using System.Threading.Tasks;
using DAL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

public class CarDetailsService : 
{
    private readonly AppDbContext _context;

    public CarDetailsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CarTechnicalDetailsViewModel> GetCarTechnicalDetailsAsync(int carId)
    {
        var car = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == carId);
        if (car == null) return null;

        return new CarTechnicalDetailsViewModel
        {
            CarId = car.CarId,
            FuelType = car.FuelType,
            Mileage = car.Mileage,
            Transmission = car.Transmission,
            FuelCapacity = car.FuelCapacity
        };
    }

    public async Task<bool> UpdateCarTechnicalDetailsAsync(int carId, CarTechnicalDetailsViewModel carTechnicalModel)
    {
        var car = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == carId);
        if (car == null) return false;

        car.FuelType = carTechnicalModel.FuelType;
        car.Mileage = carTechnicalModel.Mileage;
        car.Transmission = carTechnicalModel.Transmission;
        car.FuelCapacity = carTechnicalModel.FuelCapacity;

        await _context.SaveChangesAsync();
        return true;
    }
}
