namespace aspnet_server.Models {
    public class Address {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public Address(string Address) {
            var data = Address.Split('-', ',');

            this.Street = data[0];
            this.Number = Convert.ToInt32(data[1]);
            this.City = data[2];
        }
    }
}