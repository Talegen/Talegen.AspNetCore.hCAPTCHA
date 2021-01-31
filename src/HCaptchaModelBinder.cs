namespace Talegen.AspNetCore.hCAPTCHA
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Talegen.AspNetCore.hCAPTCHA.Properties;
    using Talegen.AspNetCore.hCAPTCHA.Providers;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    /// <summary>
    /// This class implements the model binder to validate the hCAPTCHA.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" />
    public class HCaptchaModelBinder : IModelBinder
    {
        private readonly IHCaptchaProvider captchaProvider;
        private readonly CaptchaOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="HCaptchaModelBinder" /> class.
        /// </summary>
        /// <param name="captchaProvider">The captcha provider.</param>
        /// <param name="options">The options.</param>
        public HCaptchaModelBinder(IHCaptchaProvider captchaProvider, CaptchaOptions options)
        {
            this.captchaProvider = captchaProvider;
            this.options = options;
        }

        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext">The <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext" />.</param>
        /// <exception cref="ArgumentNullException">bindingContext or HttpPostResponseKeyName</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (string.IsNullOrWhiteSpace(this.options.HttpPostResponseKeyName))
            {
                throw new ArgumentNullException(nameof(this.options.HttpPostResponseKeyName));
            }

            // validate context
            HttpContext httpContext = bindingContext.HttpContext;

            if (httpContext.Request.Method != HttpMethods.Post)
            {
                throw new InvalidOperationException(string.Format(Resources.ModelValidationMethodErrorText, nameof(HCaptchaModelBinder)));
            }

            // read token
            var token = httpContext.Request.Form[this.options.HttpPostResponseKeyName];

            try
            {
                VerifyResponse result = await this.captchaProvider.Verify(token, httpContext.Connection.RemoteIpAddress.ToString());
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (HCaptchaApiException apiException)
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, apiException.Message);
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }
    }
}