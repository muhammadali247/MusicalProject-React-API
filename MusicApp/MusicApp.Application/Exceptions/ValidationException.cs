using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
        Errors = validationResult.ToDictionary();
    }
}
