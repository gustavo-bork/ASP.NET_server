using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using aspnet_server.Models;
using Microsoft.AspNetCore.Cors;

namespace aspnet_server.Controllers {
    [ApiController]
    [Route("/api/users")]
    [EnableCors("ReactPolicy")]
    public class UserController : ControllerBase {
        /// <summary>
        /// Realiza o método GET todos os usuários
        /// </summary>
        /// <returns>
        /// No momento, uma lista de 5 usuários, todos com o mesmo nome e endereço
        /// </returns>
        [HttpGet]
        public IEnumerable<User> Get() {
            return Enumerable.Range(1, 5).Select((index) => 
                new User {
                    Id = index,
                    Username = "bátima",
                    Name = new Name {
                        FirstName = "Jão",
                        LastName = "Gabriel"
                    },
                    Address = new Address {
                        Street = "Mountain Drive",
                        Number = 1007,
                        City = "Gotham",
                    },
                    Phone = $"+{index} 91234-5678"
                }
            ).ToList();
        }

        /// <summary>
        /// Realiza o método GET de apenas 1 usuário
        /// </summary>
        /// <param name="id">O ID do usuário escolhido</param>
        /// <returns>
        /// O usuário com o ID escolhido
        /// </returns>
        [HttpGet("{id}")]
        public User Get(int id) {
            return new User {
                Id = id,
                Username = "bátima",
                Phone = $"+{id} 91234-5678",
                Name = new Name {
                    FirstName = "Jão",
                    LastName = "Gabriel"
                },
                Address = new Address {
                    City = "Gotham",
                    Number = 1007,
                    Street = "Moutain Drive"
                }
            };
        }

        /// <summary>
        /// Adiciona um usuário ao banco de dados
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] User user) {
            return user is not null && user.Id == 0 ? "sucesso" : "não foi possível adicionar";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] User user) {
            return user is not null && user.Id == id ? "sucesso" : "não foi possível atualizar";
        }

        [HttpDelete("{id}")]
        public string Delete(int id) {
            return id != 0 ? "sucesso" : "não foi possível deletar";
        }
    }
}
