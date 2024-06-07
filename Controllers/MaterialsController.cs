using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using arq_backend;
using arq_backend.Entities;
using arq_backend.Models;

namespace arq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController(AppDbContext context) : ControllerBase
    {

        private readonly AppDbContext _context = context;

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(CreateMaterial material)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == material.SubjectId);
            if(subject == null) return NotFound("Subject not found");
            var materialEntity = new Material
            {
                Name = material.Name,
                Description = material.Description,
                DocumentType = material.DocumentType,
            };

            subject.Materials ??= [];
            subject.Materials.Add(materialEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
