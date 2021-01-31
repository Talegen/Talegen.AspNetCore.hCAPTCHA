namespace Talegen.AspNetCore.hCAPTCHA
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using Talegen.AspNetCore.hCAPTCHA.Providers;

    /// <summary>
    /// This class contains the middleware extension methods for adding hCAPTCHA handler to web application.
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Adds the hCAPTCHA middleware to the services collection.
        /// </summary>
        /// <param name="services">Contains the services collection to add the provider to.</param>
        /// <param name="section">Contains a configuration section containing CAPTCHA options.</param>
        /// <returns>Returns the modified services collection.</returns>
        public static IServiceCollection AddHCaptcha(this IServiceCollection services, IConfigurationSection section)
        {
            CaptchaOptions captchaOptions = section.Get<CaptchaOptions>();
            return services.AddHCaptcha(captchaOptions);
        }

        //// <summary>
        /// Adds the hCAPTCHA middleware to the services collection.
        /// </summary>
        /// <param name="services">Contains the services collection to add the provider to.</param>
        /// <param name="siteKey">Contains the hcaptcha.com configuration site key.</param>
        /// <param name="secret">Contains the hcpatcha.com configuration secret.</param>
        /// <returns>Returns the modified services collection.</returns>
        public static IServiceCollection AddHCaptcha(this IServiceCollection services, string siteKey, string secret)
        {
            return services.AddHCaptcha(new CaptchaOptions { SiteKey = siteKey, Secret = secret });
        }

        //// <summary>
        /// Adds the hCAPTCHA middleware to the services collection.
        /// </summary>
        /// <param name="services">Contains the services collection to add the provider to.</param>
        /// <param name="options">Contains the options.</param>
        /// <returns>Returns the modified services collection.</returns>
        public static IServiceCollection AddHCaptcha(this IServiceCollection services, CaptchaOptions options)
        {
            // register the Refit REST calls client
            services.AddRefitClient<IHCaptchaApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = options.ApiBaseUrl;
            });

            services.AddScoped((s) => { return options; });
            services.AddScoped<IHCaptchaProvider, HCaptchaProvider>();

            return services;
        }
    }
}