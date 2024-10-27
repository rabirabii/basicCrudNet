using BelajarWebApi_EntityFramework.Data;
using BelajarWebApi_EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelajarWebApi_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        
        private readonly DataContext _context;

        public FirstController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Pakai iActionResult jika tidak perlu menunjukkan detil schema
        public async Task<ActionResult<List<FirstModel>>> GetAllUsers()
        {
            try {
                var users = await _context.Users.ToListAsync();

                if (users == null || !users.Any())
                {
                    return NotFound("There are no user!");
                }
                return Ok(users);


            }

            catch (Exception ex) {
                return StatusCode(500, $"Internal server Error : {ex.Message}");
            }
           
                    
        }


        [HttpGet("{id}")]
   
        public async Task<ActionResult<FirstModel>> GetUser(int id)
        {
            try {


                var users = await _context.Users.FindAsync(id);

                if (users == null)
                {
                    return NotFound($"There's no user with {id}!");
                }
                return Ok(users);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex.Message} ");
            }
       
        }

        [HttpPost]

        public async Task<ActionResult<List<FirstModel>>> AddUser(FirstModel user)
        {
            try
            {
                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return Ok(await _context.Users.ToListAsync());
            } 
            catch (Exception ex)
            {
                return StatusCode(500, $"Imternal Server error : {ex.Message}");
            }
        }

        [HttpPut]

        public async Task<ActionResult<List<FirstModel>>> UpdateUser(FirstModel UpdatedUser)
        {
            try
            {
                var user = await _context.Users.FindAsync(UpdatedUser.Id);
                if (user == null)
                {
                    return NotFound("User not found!");
                }

                user.Name = UpdatedUser.Name;
                user.firstName = UpdatedUser.firstName;
                user.lastName = UpdatedUser.lastName;
                user.Place = UpdatedUser.Place;

                await _context.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "User data has been succesfully updated.",
                        updatedUser = user
                    }
                    );
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error! {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<List<FirstModel>>> DeleteUser(int id)
        {
            try {

                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"There is no user with {id} id. ");
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "User has been Deleted"
                    });
            }

            catch (Exception ex) {

                return StatusCode(500, $"Internal Server Error! {ex.Message}");
            }
        } 
    }
}
