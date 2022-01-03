using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.DataAccess.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
