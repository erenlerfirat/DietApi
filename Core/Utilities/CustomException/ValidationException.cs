using System;

namespace Core.Utilities.CustomException
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException():base(Constants.Messages.Error)
        { }

        public ValidationException(string message)
            : base(message)
        { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
