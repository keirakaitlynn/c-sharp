using System;

namespace MvcMovie.Models
{
    public class ErrorViewModelJK
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
