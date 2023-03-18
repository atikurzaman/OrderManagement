﻿using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class OrderForCreate
    {        

        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters")]
        public string State { get; set; } = String.Empty;
    }
}