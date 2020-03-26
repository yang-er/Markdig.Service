using Markdig.Extensions.Mathematics;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Markdig.Service.Tests
{
    [TestClass]
    public class MathIntegerOnlyTest
    {
        [TestMethod]
        public void KatexExtensions()
        {
            var option = new MarkdigOptions();
            option.PipelineBuilder.Use<KatexExtension>();
            var svc = new MarkdigService(new OptionsWrapper<MarkdigOptions>(option));
            var str = svc.RenderAsHtml("$1$");
            Assert.AreEqual("<p><span class=\"katex-src\">1</span></p>\n", str);
        }
    }
}
