namespace aspnet_server.Models {
    public class Name {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Name(string Name) {
            var data = Name.Split(' ');

            this.FirstName = data[0];
            this.LastName = data[1];
        }
    }
}