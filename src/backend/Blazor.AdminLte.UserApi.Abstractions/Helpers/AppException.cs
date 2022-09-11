namespace Blazor.AdminLte.Security.Abstractions.Helpers;

using System.Globalization;

// custom exception class for throwing application specific exceptions 
// that can be caught and handled within the application
public class AppException : Exception
{
    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}