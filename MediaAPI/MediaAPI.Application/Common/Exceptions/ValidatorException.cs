namespace MediaAPI.Application.Common.Exceptions;

public class ValidatorException : Exception
{
    public ValidatorException(string message) : base(message) { }

    public ValidatorException(string[] errors) : base("One or more validation errors have ocurred.")
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}
