using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.DTO
{
    // DTO for login request
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
