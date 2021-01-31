namespace Talegen.AspNetCore.hCAPTCHA.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    /// <summary>
    /// Contains an enumerated list of error codes of the hCaptcha service response
    /// </summary>
    public enum HCaptchaVerifyErrorCode
    {
        /// <summary>
        /// The error code was unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The input secret was not provided.
        /// </summary>
        MissingInputSecret,

        /// <summary>
        /// The input secret provided was invalid.
        /// </summary>

        InvalidInputSecret,

        /// <summary>
        /// The input was missing the form response.
        /// </summary>
        MissingInputResponse,

        /// <summary>
        /// The input form response provided was invalid.
        /// </summary>
        InvalidInputRespose,

        /// <summary>
        /// The input was a bad request.
        /// </summary>
        BadRequest
    }

    /// <summary>
    /// This class contains extension methods for interacting with vierification response errors.
    /// </summary>
    public static class HCaptchaResponseExtensions
    {
        /// <summary>
        /// Contains a dictionary of error code string keys mapped to verify error code enumerations.
        /// </summary>
        /// <remarks>See https://docs.hcaptcha.com/#server for more information.</remarks>
        public static IDictionary<string, HCaptchaVerifyErrorCode> ErrorCodeDictionary = new Dictionary<string, HCaptchaVerifyErrorCode>()
        {
            { "missing-input-secret", HCaptchaVerifyErrorCode.MissingInputSecret },
            { "invalid-input-secret", HCaptchaVerifyErrorCode.InvalidInputSecret },
            { "missing-input-response",HCaptchaVerifyErrorCode.MissingInputResponse },
            { "invalid-input-response",HCaptchaVerifyErrorCode.InvalidInputRespose },
            { "bad-request", HCaptchaVerifyErrorCode.BadRequest }
        };

        /// <summary>
        /// Maps the string-based error codes to enums. Uses <see cref="ErrorCodeDictionary" /> as mapping table.
        /// </summary>
        public static List<HCaptchaVerifyErrorCode> GetErrorCodes(this VerifyResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            List<HCaptchaVerifyErrorCode> errors = new List<HCaptchaVerifyErrorCode>();

            if (response.ErrorCodes.Any())
            {
                response.ErrorCodes.ForEach(err =>
                {
                    if (ErrorCodeDictionary.TryGetValue(err, out HCaptchaVerifyErrorCode value))
                    {
                        errors.Add(value);
                    }
                    else
                    {
                        errors.Add(HCaptchaVerifyErrorCode.Unknown);
                    }
                });
            }

            return errors;
        }
    }
}