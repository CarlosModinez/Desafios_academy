using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafios_academy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Diagnostics;


namespace Desafios_academy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ReflectionContext _context;
        public UserController(ReflectionContext context) => _context = context;

        //GET: /user
        [HttpGet]
        public ActionResult Authentication(User user)
        {
            //Verificar se username existe
            var users = _context.UserItems.Where(s => s.Username.Contains(user.Username));


            if (!users.Any())
            {
                return Unauthorized();
            }

            //Verificar se senha coincide
            if (user.Password == users.First().Password)
            {
                return Ok();
            }

            else
            {
                return Unauthorized();
            }

        }

        //GET: /user/allusers
        [HttpGet("/allusers")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.UserItems;
        }


        // Get /user?=user=carlosModinez
        [HttpGet]
        [ExactQueryParam("name")]
        public ActionResult<IEnumerable<User>> GetUserByUser(string name)
        {
            var users = from m in _context.UserItems
                         select m;
            users = users.Where(s => s.Name.Contains(name));

            return users.ToList();
        }


        //POST: /user
        [HttpPost]
        public ActionResult<User> PostUserItem(User user)
        { 
            IQueryable<User> userItems = _context.UserItems.Where(x => x.Username == user.Username);
            userItems.ToList();
     
            if (userItems.Any())
            {
                return BadRequest();
            }

            if (user.Name == null)
            {
                return BadRequest();
            }

            _context.UserItems.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser(User user)
        {
            var users = _context.UserItems.Where(s => s.Username.Contains(user.Username));

            if (!users.Any())
            {
                return Forbid();
            }

            if (user.Password == users.First().Password)
            {
                _context.UserItems.Remove(users.First());
                _context.SaveChanges();

                return Ok();
            }

            else
            {
                return Unauthorized();
            }
        }
    }
}