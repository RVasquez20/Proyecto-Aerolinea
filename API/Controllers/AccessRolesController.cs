﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRolesController : ControllerBase
    {
        private readonly Aerolinea_DesarrolloContext _context;

        public AccessRolesController(Aerolinea_DesarrolloContext context)
        {
            _context = context;
        }

        // GET: api/AccessRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessRoles>>> GetAccessRoles()
        {
            if (_context.AccessRoles == null)
            {
                return NotFound();
            }
            return Ok(await _context.AccessRoles.ToListAsync());
        }

        // GET: api/AccessRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessRoles>> GetAccessRoles(int id)
        {
            var AccessRoles = await _context.AccessRoles.FindAsync(id);

            if (AccessRoles == null)
            {
                return NotFound();
            }

            return Ok(AccessRoles);
        }

        // PUT: api/AccessRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessRoles(int id, AccessRoles AccessRoles)
        {
            if (id != AccessRoles.idAccessRoles)
            {
                return BadRequest("El acceso no es valido");
            }

            _context.Entry(AccessRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessRolesExists(id))
                {
                    return NotFound("Error al actualizar el acceso");
                }
                else
                {
                    return BadRequest("Error al actualizar");
                }
            }

            return Ok(AccessRoles);
        }

        // POST: api/AccessRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccessRoles>> PostAccessRoles(AccessRoles AccessRoles)
        {

            _context.AccessRoles.Add(AccessRoles);
            await _context.SaveChangesAsync();

            return Ok(AccessRoles);
        }

        // DELETE: api/AccessRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessRoles(int id)
        {
            var AccessRoles = await _context.AccessRoles.FindAsync(id);
            if (AccessRoles == null)
            {
                return NotFound();
            }

            _context.AccessRoles.Remove(AccessRoles);
            await _context.SaveChangesAsync();

            return Ok("Acceso eliminado");
        }

        private bool AccessRolesExists(int id)
        {
            return (_context.AccessRoles?.Any(e => e.idAccessRoles == id)).GetValueOrDefault();
        }
    }
}
