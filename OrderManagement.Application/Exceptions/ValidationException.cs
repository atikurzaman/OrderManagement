﻿using FluentValidation.Results;

namespace OrderManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; }        

        public ValidationException(ValidationResult validationResult)            
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }   
        
    }
}
