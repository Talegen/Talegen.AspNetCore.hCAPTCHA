namespace Talegen.AspNetCore.hCAPTCHA.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    /// <summary>
    /// Defines the call to pass to the HCaptcha provider to verify a token using the Refit REST library.
    /// </summary>
    public interface IHCaptchaProvider
    {
        /// <summary>
        /// This request is used to verify the specified token with the hCAPTCHA API.
        /// </summary>
        /// <param name="token">Contains the client token to verify.</param>
        /// <param name="remoteAddress">Contains an optional client IP Address in.</param>
        /// <param name="cancellationToken">Contains an optional cancellation token.</param>
        /// <remarks>Timeout configuration is provided through the CancellationToken paraneter.</remarks>
        /// <returns>Returns the <see cref="VerifyResponse" /> object from the remove verification service.</returns>
        Task<VerifyResponse> Verify(string token, string remoteAddress = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests the hCaptcha API. Timeout configuration is provided via <paramref name="cancellationToken" />
        /// </summary>
        /// <param name="token">The client's token.</param>
        /// <param name="remoteAddress">Optional the client's IP address</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="HCaptchaVerifyResponse" /></returns>
        /// <exception cref="HCaptchaApiException">if request failed.</exception>
    }
}