using System.ComponentModel.DataAnnotations;

namespace Fertivue.Modal
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public string clinicName { get; set; }
        public string country { get; set; }
        public string platform { get; set; }
        public string massage { get; set; }
        public string ipaddress { get; set; }
    }
}
