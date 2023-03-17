﻿namespace OrderManagement.Application.Models
{
    public class BaseCommandResponse
    {        
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
