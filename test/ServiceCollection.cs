using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Markdig.Service.Tests
{
    [TestClass]
    public class ServiceCollectionTest
    {
        [TestMethod]
        public void ServicesAddMarkdown()
        {
            var services = new ServiceCollection();
            
            services.AddMarkdown(options =>
            {
                Assert.IsNotNull(options);
                Assert.IsNotNull(options.PipelineBuilder);
            });

            var global = services.BuildServiceProvider();
            using var scope = global.CreateScope();
            var md = scope.ServiceProvider.GetRequiredService<IMarkdownService>();
            Assert.IsNotNull(md);
        }
    }
}
