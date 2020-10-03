using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Nudes.Retornator.AspnetCore
{

    /// <summary>
    /// Retornator output formatter for StreamResult
    /// </summary>

    public class RetornartorStreamOutputFormatter : IOutputFormatter
    {
        /// <summary>
        /// Will only be able to write if context is not null and is a StreamResult without errors
        /// if has any errors will be processed by RetornatorOutputFormatter as normal
        /// </summary>
        public bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            StreamResult result = context?.Object as StreamResult;
            return result != null && result.GetError() == null; 
        }

        public async Task WriteAsync(OutputFormatterWriteContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var result = (StreamResult)context.Object;

            if (!String.IsNullOrEmpty(result.FileName))
                context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{result.FileName}\"");
            else
                context.HttpContext.Response.Headers.Add("Content-Disposition", "attachment");

            if (!String.IsNullOrEmpty(result.ContentType))
                context.HttpContext.Response.Headers.Add("Content-Type", result.ContentType);

            using var valueAsStream = result.Stream;
            await valueAsStream.CopyToAsync(context.HttpContext.Response.Body);
        }
    }
}

