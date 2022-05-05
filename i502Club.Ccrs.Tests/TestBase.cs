using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class TestBase
    {
        internal static readonly string _licenseNumber = "123456";
        internal static readonly string? _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        internal static readonly User _user = TestHelpers.GetUser();
    }
}