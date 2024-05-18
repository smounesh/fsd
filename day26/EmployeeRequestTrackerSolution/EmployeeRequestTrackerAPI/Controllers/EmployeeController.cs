﻿using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
     
        [HttpGet]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeesFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        [Authorize(Policy = "User")]
        [HttpPut]

        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }catch(NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> Post(int id ,string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch(NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        [Authorize(Policy = "Admin")]
        [Route("GetEmployeeByPhone")]
        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> GetPhone(string phone)
        {
            try
            {
                Content("Admin");
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
      }
}
