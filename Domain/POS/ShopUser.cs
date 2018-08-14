using System;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using System.Collections.Generic;
using Domain.SEG;
using Newtonsoft.Json;

namespace Domain.POS
{
    public class ShopUser
    {
        [Key]
        public int ShopUserId { get; set; }
        [Display(Name = "Sucursal")]
        public int ShopId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Shop Shop { get; set; }


    }
}
