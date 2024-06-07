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
using AutoMapper;
using NuGet.DependencyResolver;

namespace arq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController(AppDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            var materials = await _context.Materials.ToListAsync();
            var response = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                if(subject.Materials == null) subject.Materials = new List<Material>();
                response.Add(_mapper.Map<SubjectDTO>(subject));
            }
            foreach (var subject in response)
            {
                var teacher = await _context.Users.FirstOrDefaultAsync(u => u.Id == subject.TeacherId);
                if (teacher == null) throw new Exception("Teacher not found");
                subject.TeacherName = $"{teacher.FirstName} {teacher.LastName}";
            }
            return response;
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> GetSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id) ?? throw new Exception("Subject not found");
            var materials = await _context.Materials.ToListAsync();
            SubjectDTO response = _mapper.Map<SubjectDTO>(subject);
            if (subject == null)
            {
                return NotFound();
            }
            var teacher = await _context.Users.FirstOrDefaultAsync(u => u.Id == subject.TeacherId);
            if (subject.Materials == null) subject.Materials = new List<Material>();
            
            response.TeacherName = $"{teacher.FirstName} {teacher.LastName}";
            return response;
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HttpResponse>> PostSubject(CreateSubject subject)
        {
            var teacher = await _context.Users.FirstOrDefaultAsync(u => u.RoleId == subject.TeacherId);
            var newSubject = _mapper.Map<Subject>(subject);
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //add subject to an user
        [HttpPost("add")]
        public async Task<ActionResult<HttpResponse>> AddSubject(int id, int SubjectId)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found");
            user.Subjects ??= [];
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == SubjectId);
            if (subject == null) return NotFound("Subject not found");
            user.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
