namespace GBaldera.Web.Models
{
    public class MailAddress
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public static implicit operator System.Net.Mail.MailAddress(MailAddress address)
        {
            return new System.Net.Mail.MailAddress(address.Email, address.Name);
        }

        public static implicit operator MailAddress(System.Net.Mail.MailAddress address)
        {
            return new MailAddress{Email = address.Address, Name = address.DisplayName};
        }
    }
}
