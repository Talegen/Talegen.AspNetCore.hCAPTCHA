namespace Talegen.AspNetCore.hCAPTCHA
{
    using System;

    /// <summary>
    /// This class contains the hCAPTCHA settings for the middleware.
    /// </summary>
    public class CaptchaOptions
    {
        /// <summary>
        /// Gets or sets the site key.
        /// </summary>
        /// <value>The site key.</value>
        public string SiteKey { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        /// <value>The secret.</value>
        public string Secret { get; set; }

        /// <summary>
        /// The HTTP Post Form Key to get the token from
        /// </summary>
        public string HttpPostResponseKeyName { get; set; } = "h-captcha-response";

        /// <summary>
        /// if true client IP is passed to hCaptcha token verification
        /// </summary>
        public bool VerifyRemoteAddress { get; set; } = true;

        /// <summary>
        /// Full Url to hCaptchy JavaScript
        /// </summary>
        public Uri JavaScriptUrl { get; set; } = new Uri("https://hcaptcha.com/1/api.js");

        /// <summary>
        /// Gets or sets the API base URL.
        /// </summary>
        /// <value>The API base URL.</value>
        public Uri ApiBaseUrl { get; set; } = new Uri("https://hcaptcha.com/");
    }
}