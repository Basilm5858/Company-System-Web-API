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
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.ProjectCustomRepo.GetAll();
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<ProjectDTO>>(departments);
            return Ok(res);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var departments = await _unitOfWork.ProjectCustomRepo.GetById(id);
            if (departments == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ProjectDTO>(departments);
            return Ok(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreateProjectDTO dto)
        {
            var res = _mapper.Map<Project>(dto);
            await _unitOfWork.ProjectCustomRepo.Add(res);
            await _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateProjectDTO dto)
        {
            var employee = _unitOfWork.ProjectCustomRepo.GetById(id);
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
            var res = await _unitOfWork.ProjectCustomRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            _unitOfWork.ProjectCustomRepo.Delete(res);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
