using System.ComponentModel.DataAnnotations;

namespace AkademiPlus.IdentityServer.Dtos
{
    public class SignUpDto
    {

        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

    }
}
