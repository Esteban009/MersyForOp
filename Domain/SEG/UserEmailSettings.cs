using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SEG
{
    public class UserEmailSetting
    {
        public int UserEmailSettingId { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string HostNameSmtp { get; set; }

        public int Port { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }


    }
}
