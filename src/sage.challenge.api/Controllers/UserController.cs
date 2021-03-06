using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using sage.challenge.repository;
using sage.challenge.data.Entities;
using sage.challenge.framework;

namespace sage.challenge.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesResource.Status500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await userRepository.GetUserById(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesResource.Status500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                    return BadRequest();

                //Check email is not duplicated
                if (!userRepository.IsEmailUnique(user.Email).Result)
                {
                    ModelState.AddModelError("Email", MessagesResource.DuplicateEmail);
                    return BadRequest(ModelState);
                }

                // check minimum legal age for registration
                Helper helper = new Helper();
                if (!helper.IsAgeLegal(user.DateOfBirth))
                    return BadRequest(MessagesResource.NotValidAge);

                var createdUser = await userRepository.AddUser(user);

                return StatusCode(StatusCodes.Status201Created, CreatedAtAction(nameof(GetUser), new { id = createdUser.Id },
                    createdUser));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesResource.Status500);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                    return BadRequest();

                if (id != user.Id)
                    return BadRequest(MessagesResource.UserIdMismatch);

                var userToUpdate = await userRepository.GetUserById(id);

                if (userToUpdate == null)
                    return NotFound(MessagesResource.UserNotFound);

                //Check email is not duplicate
                //if the email address was duplicated and it wasn't for the current user
                if (!userRepository.IsEmailUnique(user.Email, id).Result)
                {
                    ModelState.AddModelError("Email", MessagesResource.DuplicateEmail);
                    return BadRequest(ModelState);
                }

                // check minimum legal age for registration
                Helper helper = new Helper();
                if (!helper.IsAgeLegal(user.DateOfBirth))
                    return BadRequest(MessagesResource.NotValidAge);

                return Ok(await userRepository.UpdateUser(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesResource.Status500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await userRepository.GetUserById(id);

                if (userToDelete == null)
                {
                    return NotFound(MessagesResource.UserNotFound);
                }
                return Ok(await userRepository.DeleteUser(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, MessagesResource.Status500);
            }
        }
    }
}
