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
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.EmployeeCustomRepo.GetAll();
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<EmployeeDTO>>(departments);
            return Ok(res);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var departments = await _unitOfWork.EmployeeCustomRepo.GetById(id);
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<EmployeeDTO>(departments);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateEmployeeDTO dto)
        {
            var res = _mapper.Map<Employee>(dto);
            await _unitOfWork.EmployeeCustomRepo.Add(res);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDTO dto)
        {
            var employee = _unitOfWork.EmployeeCustomRepo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _mapper.Map(employee, dto);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _unitOfWork.EmployeeCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            _unitOfWork.EmployeeCustomRepo.Delete(res);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var departments = await _unitOfWork.EmployeeCustomRepo.GetByName(name);
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }

        [HttpGet("GetByDepId")]
        public async Task<IActionResult> GetByDepId(int depid)
        {
            var departments = await _unitOfWork.EmployeeCustomRepo.GetByDepId(depid);
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }
    }
}
