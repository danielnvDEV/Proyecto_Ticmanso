using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicmansoV2.Shared;
using TicmansoWebApiV2.Context;

namespace TicmansoWebApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        private readonly TicmansoDbContext _context;


        public UserImageController(TicmansoDbContext context)
        {
            _context = context;            
        }

        [HttpGet("GetAllUserImages")]
        public async Task<IActionResult> GetAllUserImages()
        {
            var userImages = await _context.UserImages.ToListAsync();

            if (userImages.Count > 0)
            {
                var imageList = userImages.Select(ui => new
                {
                    UserId = ui.IdUser,
                    Image = Convert.ToBase64String(ui.Image)
                }).ToList();

                return Ok(imageList);
            }

            return NotFound("No se han encontrado imagenes");
        }

        [HttpPut]
        public async Task<IActionResult> UploadUserImage([FromBody] UserImageDTO imageDTO)
        {
            try
            {
                var existingUserImage = await _context.UserImages.FirstOrDefaultAsync(ui => ui.IdUser == imageDTO.IdUser);

                if (existingUserImage != null)
                {
                    
                    existingUserImage.FileName = imageDTO.FileName;
                    existingUserImage.Image = imageDTO.Image;
                }
                else
                {
                    
                    var userImage = new UserImage
                    {
                        IdUser = imageDTO.IdUser,
                        FileName = imageDTO.FileName,
                        Image = imageDTO.Image
                    };

                    _context.UserImages.Add(userImage);
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al subir la imagen: {ex.Message}");
            }
        }


        [HttpGet("GetUserImage/{userId}")]
        public async Task<IActionResult> GetUserImage(string userId)
        {
            var userImage = await _context.UserImages.FirstOrDefaultAsync(u => u.IdUser == userId);
            if (userImage != null)
            {
                return File(userImage.Image, "image/jpeg");
            }
            return NotFound();
        }

        [HttpDelete("DeleteUserImage/{userId}")]
        public async Task<IActionResult> DeleteUserImage(string userId)
        {
            var userImage = await _context.UserImages.FirstOrDefaultAsync(u => u.IdUser == userId);
            if (userImage != null)
            {
                _context.UserImages.Remove(userImage);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}

