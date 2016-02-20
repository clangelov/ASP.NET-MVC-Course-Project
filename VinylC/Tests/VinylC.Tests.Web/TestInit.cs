namespace VinylC.Tests.Web
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VinylC.Common.Constants;
    using VinylC.Web.MVC;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assemblies.MVCProject);
        }
    }
}
