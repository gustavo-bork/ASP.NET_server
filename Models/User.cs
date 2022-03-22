using System.ComponentModel.DataAnnotations;

namespace aspnet_server.Models {
    public class User {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
    }
}