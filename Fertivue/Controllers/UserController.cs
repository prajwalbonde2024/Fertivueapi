using EComApplication.Services;
using Fertivue.DataContext;
using Fertivue.Modal;
using Fertivue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fertivue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.User.ToList();
            return Ok(users);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult SaveUser(UserDto user)
        {
            // Map DTO to Entity
            var userDetails = new Users
            {
                UserName = user.UserName,
                email = user.email,
                clinicName = user.clinicName,
                country = user.country,
                platform = user.platform,
                massage = user.massage,
                ipaddress = user.ipaddress
            };

            // Save to Database
            _dbContext.User.Add(userDetails);
            _dbContext.SaveChanges();

            // Send Email if email exists
            if (!string.IsNullOrEmpty(user.email))
            {
                SendmailService mail = new SendmailService(user.email, user.UserName);
                mail.SendMail();
            }

            return Ok("User saved successfully!");
        }
    }
}
