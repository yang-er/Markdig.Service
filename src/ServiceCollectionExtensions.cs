using Markdig.Extensions.Mathematics;
using Markdig.Extensions.Toc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Markdig
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMarkdown(
            this IServiceCollection services,
            Action<MarkdigOptions> action = null)
        {
            services.AddTransient<IMarkdownService, MarkdigService>();

            services.Configure<MarkdigOptions>(options =>
            {
                options.PipelineBuilder
                    .Use<KatexExtension>()
                    .Use<HeadingIdExtension>()
                    .UseSoftlineBreakAsHardlineBreak()
                    .UseNoFollowLinks()
                    .UsePipeTables()
                    .UseBootstrap();

                action?.Invoke(options);
            });
            
            return services;
        }
    }
}
