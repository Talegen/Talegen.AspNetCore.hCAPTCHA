namespace Talegen.AspNetCore.hCAPTCHA.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Refit;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    /// <summary>
    /// HCaptcha Provider - API communication
    /// </summary>
    public class HCaptchaProvider : IHCaptchaProvider
    {
        /// <summary>
        /// Coontains the captcha API
        /// </summary>
        private readonly IHCaptchaApi captchaApi;

        /// <summary>
        /// Contains the options
        /// </summary>
        private readonly CaptchaOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="HCaptchaProvider" /> class.
        /// </summary>
        /// <param name="captchaApi">Contains an instance of the hCAPTCHA API implementation.</param>
        /// <param name="captchaOptions">Contains an options accessor for the <see cref="CaptchaOptions" /> settings.</param>
        public HCaptchaProvider(IHCaptchaApi captchaApi, CaptchaOptions captchaOptions)
        {
            this.captchaApi = captchaApi;
            this.options = captchaOptions;
        }

        /// <summary>
        /// This request is used to verify the specified token with the hCAPTCHA API.
        /// </summary>
        /// <param name="token">Contains the client token to verify.</param>
        /// <param name="remoteAddress">Contains an optional client IP Address in.</param>
        /// <param name="cancellationToken">Contains an optional cancellation token.</param>
        /// <returns>Returns the <see cref="VerifyResponse" /> object from the remove verification service.</returns>
        /// <exception cref="HCaptchaApiException"></exception>
        /// <remarks>Timeout configuration is provided through the CancellationToken paraneter.</remarks>
        public async Task<VerifyResponse> Verify(string token, string remoteAddress = null, CancellationToken cancellationToken = default)
        {
            try
            {
                return await this.captchaApi.Verify(this.options.Secret, token, this.options.VerifyRemoteAddress ? remoteAddress : null, cancellationToken).ConfigureAwait(false);
            }
            catch (ApiException e)
            {
                throw new HCaptchaApiException(e.StatusCode, e);
            }
        }
    }
}