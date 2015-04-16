using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenBonny.KeybaseSharp.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public async void LookupTestKnownUser()
        {
            var user = new User();
            var userLookup = await user.LookupAsync("kenbonny", ProofType.Usernames);

            Assert.IsNotNull(userLookup);
            Assert.AreEqual(0, userLookup.Status.Code);
            Assert.AreEqual("Ken Bonny", userLookup.Them.Profile.FullName);
        }

        [TestMethod]
        public async void LookupTestUnknownUser()
        {
            var user = new User();
            var userLookup = await user.LookupAsync("bla", ProofType.Usernames);

            Assert.IsNotNull(userLookup);
            Assert.AreEqual(205, userLookup.Status.Code);
            Assert.AreEqual("NOT_FOUND", userLookup.Status.Name);
        }
    }
}
