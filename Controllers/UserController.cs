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
        private AspNetServerContext context = new AspNetServerContext();

        /// <summary>
        /// Realiza o método GET todos os usuários
        /// </summary>
        /// <returns>Todos os usuários no banco de dados. Se não houver nenhum, retorna um array vazio</returns>
        [HttpGet]
        public IEnumerable<User> Get() {
            try {
                return context.Users.ToList();
            } catch (Exception) {
                return null;
            }
        }
        

        /// <summary>
        /// Realiza o método GET de apenas 1 usuário
        /// </summary>
        /// <param name="id">O ID do usuário escolhido</param>
        /// <returns>O usuário com o ID escolhido. Se não houver, retorna null</returns>
        [HttpGet("{id}")]
        public User Get(int id) {
            try {
                return context.Users.FirstOrDefault(user => user.Id == id);
            } catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// Adiciona um usuário ao banco de dados
        /// </summary>
        /// <param name="user">Usuário a ser adicionado</param>
        /// <returns>
        /// Retorna true se o usuário foi adicionado com sucesso. 
        /// Se não foi, retorna false
        /// </returns>
        [HttpPost]
        public bool Post([FromBody] User user) {
            try {
                if(user is null || user.Id != 0) throw new Exception();

                context.Users.Add(user);
                var num = context.SaveChanges();
            } catch (Exception) {
                return false;
            }            
            return true;
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] User user) {
            try {
                if(user is null || user.Id != id || id == 0) throw new Exception();
                
                context.Users.Update(user);
                var num = context.SaveChanges();
            } catch(Exception) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">ID do usuário a ser removido</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool Delete(int id) {
            try {
                if(id == 0) throw new Exception();

                var user = context.Users.FirstOrDefault(user => user.Id == id);
                context.Users.Remove(user);
                context.SaveChanges();
            } catch (Exception) {
                return false;
            }
            return true;
        }
    }
}
