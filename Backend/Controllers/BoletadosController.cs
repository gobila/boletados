using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletadosController : ControllerBase
    {
        private readonly BoletadosContext _context;

        public BoletadosController(BoletadosContext context)
        {
            _context = context;
        }
        // GET: api/Boletados/login
        [HttpPost]
        [Route("login")]    
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var userExists = new UserRepository().GetByUsername(model.Username);

            if (userExists == null)
                return BadRequest(new { Message = "Username e/ou senha está(ão) inválido(s)." });

            
            if(userExists.Password != model.Password)
                return BadRequest(new { Message = "Username e/ou senha está(ão) inválido(s)." });


            var token = TokenService.GenerateToken(userExists);

            return Ok(new
            {
                Token = token,
                Usuario = userExists
            });
        }
        
        // GET: api/Boletados/user
        [HttpGet]
        [Route("user")]
        public IActionResult GetUsers()
        {
            return Ok("Olá " + User.Identity.Name + " rota aberta a todos os colaboradores.");
        }

        // GET: api/Boletados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boletados>>> GetBoletados()
        {
            return await _context.Boletados.ToListAsync();
        }

        // GET: api/Boletados/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Boletados>> GetBoletados(long id)
        {
            var boletados = await _context.Boletados.FindAsync(id);

            if (boletados == null)
            {
                return NotFound();
            }

            return boletados;
        }
        
        // GET: api/Boletados/UF/go
        [HttpGet]
        [Route("uf/{uf}")]
        public async Task<IQueryable<Boletados>> GetBoletadosUF(string uf)
        {
            //var boletados = await _context.Boletados.FirstOrDefaultAsync(x=> x.UF==uf);
            var boletados = _context.Boletados.Where(x=> x.UF.Contains(uf));

            if (boletados == null)
            {
                return (IQueryable<Boletados>)NotFound();
            }

            return boletados;;
        }

        // PUT: api/Boletados/att/5
        [HttpPut("{id}")]
        [Route("update/{id}")]
        public async Task<IActionResult> PutBoletados(long id, Boletados boletados)
        {
            if (id != boletados.Id)
            {
                return BadRequest();
            }

            _context.Entry(boletados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Boletados/cadastro
        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<Boletados>> PostBoletados(Boletados boletados)
        {
            _context.Boletados.Add(boletados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoletados), new { id = boletados.Id }, boletados);
            
        }

        // DELETE: api/Boletados/delete/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteBoletados(long id)
        {
            var boletados = await _context.Boletados.FindAsync(id);
            if (boletados == null)
            {
                return NotFound();
            }

            _context.Boletados.Remove(boletados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletadosExists(long id)
        {
            return _context.Boletados.Any(e => e.Id == id);
        }
    }
}
