using DriversApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DriversApp.Controllers
{
    public class ManagersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ManagersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetManagers()
        {
            try
            {
                return Ok(unitOfWork.ManagerRepository.GetAllManagers());
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
    }
}
