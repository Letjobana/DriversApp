using DriversApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RequirementsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetRequirements()
        {
            try
            {
                return Ok(unitOfWork.RequirementRepository.GetAllRequirement());
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
