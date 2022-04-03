using System.ComponentModel.DataAnnotations;

namespace aspnet_server.Models {
    public class Name {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}