using AutoMapper;
using Campany.DTOs;
using Campany.Models;
using Campany.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var departments = await _unitOfWork.EmployeeProjectCustomRepo.GetById(id);
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<EmployeeProjectDTO>(departments);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateEmployeeProjectDTO dto)
        {
            var res = _mapper.Map<EmployeeProject>(dto);
            await _unitOfWork.EmployeeProjectCustomRepo.Add(res);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [HttpGet("GetByEmpId")]
        public async Task<IActionResult> GetByEmpId(int empid)
        {
            var emp = await _unitOfWork.EmployeeProjectCustomRepo.GetByEmpId(empid);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
    }
}
