using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspnet_server.Models;
using Microsoft.AspNetCore.Cors;

namespace aspnet_server.Controllers {
    [ApiController]
    [Route("/api/users")]
    [EnableCors("ReactPolicy")]
    public class UserController : ControllerBase {
        private static readonly string[] Names = new [] {
            "John Doe", "John Morrison", "Kevin Ryan", "Ben Dover", "Mike Coxlong"
        };
        private static readonly string[] Addresses = new[] {
            "New Road, 7682 - KilCoole",
            "Lovers Ln, 7267 - Kilcoole",
            "Frances Ct, 86 - Cullman",
            "Hunters Creek Dr, 6454 - San Antonio",
            "Adams St, 245 - San Antonio"
        };

        [HttpGet]
        public IEnumerable<User> Get() {
            return Enumerable.Range(1, 5).Select((index) => 
                new User {
                    Id = index,
                    Username = string.Empty,
                    Name = new Name(Names[index - 1]),
                    Address = new Address(Addresses[index - 1]),
                    Phone = string.Empty
                }
            ).ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id) {
            return new User {
                Id = id,
                Username = string.Empty,
                Phone = string.Empty,
                Name = new Name(Names[id - 1]),
                Address = new Address(Addresses[id - 1])
            };
        }

        [HttpPost]
        public void Post([FromBody] User user) {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user) {

        }

        [HttpDelete("{id}")]
        public void Delete(int id) {

        }
    }
}
