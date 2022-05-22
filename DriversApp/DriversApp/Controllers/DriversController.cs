using DriversApp.Repositories.Abstracts;
using DriversApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Controllers
{
    public class DriversController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetDriversInformation()
        {
            try
            {
                return Ok(unitOfWork.DriversRepository.GetAllDrivers());
            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(new
                {
                    Message = "An error occurred while retrieving data from the database. " +
                      "Please try again, and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
        [HttpGet]
        public IActionResult GetById(int driverId)
        {
            try
            {
                return Ok(unitOfWork.DriversRepository.GetDriverById(driverId));

            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occurred while retrieving data from the database. " +
                      "Please try again, and if the problem persists, contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;

            }
        }

        [HttpPost]
        public IActionResult AddNewDriver(DriverViewModel driver)
        {
            try
            {
                if (unitOfWork.DriversRepository.DriverExist(driver.Email))
                {
                    var errorObjectResult = new ObjectResult(new
                    {
                        Message = "This driver has already been added to the database",
                        Status = "Error",
                    });
                    errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                    return errorObjectResult;
                }
                else
                    unitOfWork.DriversRepository.AddDriver(driver);
                return Ok(new { Message = "A new driver has been successfully added", Status = "Success" });

            }
            catch (Exception ex)
            {

                var errorObjectResult = new ObjectResult(new
                {
                    Message = "An error occurred while adding the driver. " +
                    "Please try again, and if the problem persists,contact support@gmail.com",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
        [HttpPut]
        public IActionResult UpdateDriver(DriverViewModel driver)
        {
            try
            {
                if (!unitOfWork.DriversRepository.DriverExist(driver.Email))
                {
                    var errorObjectResult = new ObjectResult(new
                    {
                        Message = "This driver does not exist,please add the driver first",
                        Status = "Error",
                    });
                    errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                    return errorObjectResult;
                }
                else
                    unitOfWork.DriversRepository.UpdateDriver(driver);
                return Ok(new
                {
                    Message = "Successfully Updated",
                    Status = "Sucess"
                });
            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while trying to update the employee",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;
            }

        }
        [HttpDelete]
        public IActionResult DeleteDriver(int Id)
        {
            try
            {
                unitOfWork.DriversRepository.DeleteDriver(Id);
                return Ok(new
                {
                    Message = "Deleted Succesfully",
                    Status = "Success"
                });
            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while trying to delete the employee",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;
            }
        }
    }
}
