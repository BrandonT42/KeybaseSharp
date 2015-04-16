using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenBonny.KeybaseSharp.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void LookupTestKnownUser()
        {
            var user = new User();
            var userLookup = user.LookupAsync("kenbonny", ProofType.Usernames).Result;

            Assert.IsNotNull(userLookup);
            Assert.AreEqual(0, userLookup.Status.Code);
            Assert.AreEqual("Ken Bonny", userLookup.Them.First().Profile.FullName);
        }

        [TestMethod]
        public void LookupTestUnknownUser()
        {
            var user = new User();
            var userLookup = user.LookupAsync("bla", ProofType.Usernames).Result;

            Assert.IsNotNull(userLookup);
            Assert.AreEqual(205, userLookup.Status.Code);
            Assert.AreEqual("NOT_FOUND", userLookup.Status.Name);
        }
    }
}
