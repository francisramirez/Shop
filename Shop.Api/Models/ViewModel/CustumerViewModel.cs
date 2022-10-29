namespace Shop.Api.Models.ViewModel
{
    public class CustumerViewModel
    {
        public CustumerViewModel(Customers customer)
        {
            this.CustumerId = customer.Custid;
            this.Address = customer.Address;
            this.City = customer.City;
            this.Companyname = customer.Companyname;
            this.Contactname = customer.Contactname;
            this.Contacttitle = customer.Contacttitle;
            this.Country = customer.Country;
            this.Fax = customer.Fax;
            this.Phone = customer.Phone;
            this.Postalcode = customer.Postalcode;
            this.Region = customer.Region;
            this.Email = customer.Email;
        }

        public int CustumerId { get; set; }
        public string Companyname { get; set; }
        public string Contactname { get; set; }
        public string Contacttitle { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
