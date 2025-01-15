﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName  { get; set; } = "";

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        [Required]
        public string Status { get; set; } = ""; //New, Permanent, Lead, Occasional, Inactive
    }
}
