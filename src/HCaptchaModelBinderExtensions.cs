namespace Talegen.AspNetCore.hCAPTCHA
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This class contains model binder extension methods for the MVC options binder.
    /// </summary>
    public static class HCaptchaModelBinderExtensions
    {
        /// <summary>
        /// Adds the h captcha model binder.
        /// </summary>
        /// <param name="mvcOptions">The MVC options.</param>
        /// <param name="captchaModelBinderOptions">The captcha model binder options.</param>
        /// <returns></returns>
        public static MvcOptions AddHCaptchaModelBinder(this MvcOptions mvcOptions, Action<HCaptchaModelBinderOptions> captchaModelBinderOptions = null)
        {
            HCaptchaModelBinderOptions options = new HCaptchaModelBinderOptions();
            captchaModelBinderOptions?.Invoke(options);

            // add binder provider
            mvcOptions.ModelBinderProviders.Insert(options.BinderPosition, new AuthorEntityBinderProvider());

            return mvcOptions;
        }
    }
}