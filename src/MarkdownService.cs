using Markdig.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Markdig
{
    /// <summary>
    /// Provide easy access for projects using dependency injection.<br/>
    /// This service should be registered as <see cref="ServiceLifetime.Transient"/>.
    /// </summary>
    public interface IMarkdownService
    {
        /// <summary>
        /// Parsing pipeline
        /// </summary>
        MarkdownPipeline Pipeline { get; }

        /// <summary>
        /// Parse the source into AST
        /// </summary>
        /// <param name="source">Markdown source</param>
        /// <returns>Markdown document</returns>
        MarkdownDocument Parse(string source);

        /// <summary>
        /// Translate the document into a HTML document.
        /// </summary>
        /// <param name="doc">Markdown document</param>
        /// <returns>HTML content</returns>
        string RenderAsHtml(MarkdownDocument doc);

        /// <summary>
        /// Generate the TOC of document into HTML
        /// </summary>
        /// <param name="doc">Markdown document</param>
        /// <returns>HTML content</returns>
        string TocAsHtml(MarkdownDocument doc);

        /// <summary>
        /// Tranverse the AST of source, and convert the images url by converter. <br/>
        /// Usually used for import or export documents and translate between base64 and physical files. <br/>
        /// </summary>
        /// <param name="source">Markdown source</param>
        /// <param name="converter">Url translator</param>
        /// <returns>A task for the translated source</returns>
        Task<string> SolveImagesUrlAsync(string source, Func<string, Task<string>> converter);
    }
}
