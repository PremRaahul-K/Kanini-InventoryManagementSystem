﻿using System.ComponentModel.DataAnnotations;

namespace Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
    }
}
