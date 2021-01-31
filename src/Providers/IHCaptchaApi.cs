namespace Talegen.AspNetCore.hCAPTCHA.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Refit;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    public interface IHCaptchaApi
    {
        /// <summary>
        /// This defines the endpoint which is called to verify the site.
        /// </summary>
        /// <param name="secret">Contains the API key and response token.</param>
        /// <param name="response">Contains the response from the HTML page..</param>
        /// <param name="remoteAddress">Contains an optional remote IP Address.</param>
        /// <param name="cancellationToken">Contains an optional cancellation token.</param>
        /// <returns>Returns the <see cref="VerifyResponse" /> response object.</returns>
        [Post("/siteverify")]
        Task<VerifyResponse> Verify(string secret, string response, string remoteAddress = null, CancellationToken cancellationToken = default);
    }
}