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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.DepartmentCustomRepo.GetAll();
            if(departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<DepartmentDTO>>(departments);
            return Ok(res);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var departments = await _unitOfWork.DepartmentCustomRepo.GetById(id);
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<DepartmentDTO>(departments);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateDepartmentDTO dto)
        {
            var res = _mapper.Map<Department>(dto);
            await _unitOfWork.DepartmentCustomRepo.Add(res);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentDTO dto)
        {
            var department = _unitOfWork.DepartmentCustomRepo.GetById(id);
            if(department == null)
            {
                return NotFound();
            }
            _mapper.Map(department, dto);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _unitOfWork.DepartmentCustomRepo.GetById(id);
            if(res == null)
            {
                return NotFound();
            }
            _unitOfWork.DepartmentCustomRepo.Delete(res);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }



    }
}
