namespace Talegen.AspNetCore.hCAPTCHA.Providers.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the JSON model response from the hCAPTCHA verification REST call.
    /// </summary>
    /// <remarks>See https://docs.hcaptcha.com/#server for more information.</remarks>
    public class VerifyResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VerifyResponse" /> was successful.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        /// <value>The timestamp.</value>
        [JsonProperty("challenge_ts")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the hostname where the CAPTCHA was resolved.
        /// </summary>
        /// <value>The hostname.</value>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets an optional value indicating whether this <see cref="VerifyResponse" /> is credited.
        /// </summary>
        /// <value><c>true</c> if credit; otherwise, <c>false</c>.</value>
        [JsonProperty("credit")]
        public bool Credit { get; set; }

        /// <summary>
        /// Gets or sets any error codes returned from the service.
        /// </summary>
        /// <value>The error codes.</value>
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; } = new List<string>();
    }
}