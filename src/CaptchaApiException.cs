namespace Talegen.AspNetCore.hCAPTCHA
{
    using System;
    using System.Net;
    using Refit;
    using Talegen.AspNetCore.hCAPTCHA.Properties;

    /// <summary>
    /// hCapcha API Exception
    /// </summary>
    /// <remarks>Inner exception is a of type <see cref="ApiException" /> which is a part of Refit.</remarks>
    public class HCaptchaApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HCaptchaApiException" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="apiException">The API exception.</param>
        public HCaptchaApiException(HttpStatusCode statusCode, ApiException apiException)
            : base(Resources.ApiExceptionErrorText, apiException)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; }
    }
}