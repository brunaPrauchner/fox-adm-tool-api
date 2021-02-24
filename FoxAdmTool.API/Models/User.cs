using System.Collections.Generic;

namespace FoxAdmTool.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public IList<UserProduct> UserProducts { get; set; }
    }
}