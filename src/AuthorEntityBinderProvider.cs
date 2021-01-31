namespace Talegen.AspNetCore.hCAPTCHA
{
    using System;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using Talegen.AspNetCore.hCAPTCHA.Providers.Models;

    /// <summary>
    /// This class implements a model binder provider for verification models.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider" />
    public class AuthorEntityBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Creates a <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" /> based on <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.</param>
        /// <returns>An <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" />.</returns>
        /// <exception cref="ArgumentNullException">context</exception>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            IModelBinder binder = null;

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(VerifyResponse))
            {
                binder = new BinderTypeModelBinder(typeof(HCaptchaModelBinder));
            }

            return binder;
        }
    }
}