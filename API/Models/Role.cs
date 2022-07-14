﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role Name Can't Empty, Try Again !")]
        public string Name { get; set; }
    }
}
