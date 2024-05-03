using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Common
{
    public class HttpRequestResponse<T>
    {
        public T Result { get; set; }
        public List<ErrorMessage> ErrorMessages { get; set; }

        public HttpRequestResponse()
        {
            ErrorMessages = new List<ErrorMessage>();
        }

        public HttpRequestResponse(T result) : this()
        {
            Result = Result;
        }

        public void AddErrorMessage(ErrorMessage message)
        {
            ErrorMessages.Add(message);
        }
        public void AddErrorMessages(List<ErrorMessage> errorMessages)
        {
            ErrorMessages.AddRange(errorMessages);
        }
    }
}
