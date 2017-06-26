namespace VinylC.Common.RegexCompileDll
{
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void CompileDll()
        {
            RegexCompilationInfo HashTagPattern =
                               new RegexCompilationInfo(@"#[A-Za-z0-9]{3,}",
                                                    RegexOptions.None,
                                                    "HashTagPattern",
                                                    "VinylC.Common.Regex",
                                                    true);

            RegexCompilationInfo[] regexes = { HashTagPattern };

            AssemblyName assemName = new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");

            Regex.CompileToAssembly(regexes, assemName);
        }
    }
}
