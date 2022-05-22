using DriversApp.Data;
using DriversApp.Models;
using DriversApp.Repositories.Abstracts;
using DriversApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DriversApp.Repositories.Concrets
{
    public class DriversRepository : IDriversRepository
    {
        private readonly ApplicationDbContext context;

        public DriversRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Driver AddDriver(DriverViewModel driver)
        {
            try
            {
                var candidate = new Driver
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    Email = driver.Email,
                    Department = driver.Department,
                    Section = driver.Section,
                    Requirement = driver.Requirement,
                    ManagerId = driver.ManagerId
                };
                context.Drivers.Add(candidate);
                context.SaveChanges();
                return candidate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteDriver(int driverId)
        {
            try
            {
                var driver = context.Drivers.Where(x => x.Id == driverId).FirstOrDefault();
                if (driver != null)
                {
                    context.Drivers.Remove(driver);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DriverExist(string email)
        {
            try
            {
                bool existDriver = context.Drivers.Any(x => x.Email.Equals(email));
                return existDriver;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            try
            {
                return context.Drivers.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Driver GetDriverById(int driverId)
        {
            try
            {
                return context.Drivers.Find(driverId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateDriver(DriverViewModel driver)
        {
            try
            {
                var updateDriver = context.Drivers.Where(x => x.Id == driver.Id).FirstOrDefault();
                if (updateDriver != null)
                {
                    updateDriver.FirstName = driver.FirstName;
                    updateDriver.LastName = driver.LastName;
                    updateDriver.Email = driver.Email;
                    updateDriver.Department = driver.Department;
                    updateDriver.Section = driver.Section;
                    updateDriver.Requirement = driver.Requirement;
                    updateDriver.ManagerId = driver.ManagerId;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
