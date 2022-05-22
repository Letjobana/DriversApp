using DriversApp.Models;
using DriversApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Repositories.Abstracts
{
    public interface IDriversRepository
    {
        IEnumerable<Driver> GetAllDrivers();
        Driver AddDriver(DriverViewModel driver);
        bool DriverExist(string email);
        Driver GetDriverById(int driverId);
        void UpdateDriver(DriverViewModel driver);
        void DeleteDriver(int driverId);
    }
}
