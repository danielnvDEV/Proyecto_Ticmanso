﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicmansoWebApiV2.Context;
using TicmansoV2.Shared;

namespace TicmansoWebApiV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TicmansoDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(TicmansoDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserDTO>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var userDTOs = users.Select(user => new ApplicationUserDTO
            {
                Id = user.Id,
                CompanyId = user.Companyid,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            });

            return Ok(userDTOs);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUserDTO>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new ApplicationUserDTO
            {
                Id = user.Id,
                CompanyId = user.Companyid,
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };

            return userDTO;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, ApplicationUserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Companyid = userDTO.CompanyId;
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.UserName = userDTO.UserName;
            user.PhoneNumber = userDTO.PhoneNumber;

            try
            {
                await _userManager.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<ApplicationUserDTO>> PostUser(ApplicationUserDTO userDTO)
        {
            var user = new ApplicationUser
            {
                Companyid = userDTO.CompanyId,
                Name = userDTO.Name,
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                PhoneNumber = userDTO.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                var createdUserDTO = new ApplicationUserDTO
                {
                    Id = user.Id,
                    CompanyId = user.Companyid,
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber
                };

                return CreatedAtAction("GetUser", new { id = user.Id }, createdUserDTO);
            }

            return BadRequest(result.Errors);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        [HttpPost("{userId}/roles")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID '{userId}' not found.");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok($"Role '{roleName}' assigned to user '{user.UserName}' successfully.");
            }

            return BadRequest($"Failed to assign role '{roleName}' to user '{user.UserName}'. Errors: {string.Join(", ", result.Errors)}");
        }

        [HttpDelete("{userId}/roles/{roleName}")]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID '{userId}' not found.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok($"Role '{roleName}' removed from user '{user.UserName}' successfully.");
            }

            return BadRequest($"Failed to remove role '{roleName}' from user '{user.UserName}'. Errors: {string.Join(", ", result.Errors)}");
        }
    }
}