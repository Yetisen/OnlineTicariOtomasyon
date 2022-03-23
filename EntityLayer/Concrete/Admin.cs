﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Password { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Role { get; set; }
    }
}
