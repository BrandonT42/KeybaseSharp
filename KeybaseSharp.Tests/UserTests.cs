using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenBonny.KeybaseSharp.Tests
{
    [TestClass]
    public class UserTests
    {
        public User User { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            User = new User();
        }

        [TestMethod]
        public void LookupTestKnownUser()
        {
            var lookupTask = User.LookupAsync("kenbonny", ProofType.Usernames);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.AreEqual("Ken Bonny", lookup.Them.First().Profile.FullName);
        }

        [TestMethod]
        public void LookupTestUnknownUser()
        {
            var lookup = User.LookupAsync("bla", ProofType.Usernames).Result;

            Assert.IsNotNull(lookup);
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.All(u => u == null));
            Assert.IsFalse(string.IsNullOrEmpty(lookup.CsrfToken));
        }

        [TestMethod]
        public void AutocompleteTest()
        {
            const string partial = "kenbo";

            var autocompleteTask = User.AutocompleteAsync(partial);
            Assert.IsNotNull(autocompleteTask);

            var autocomplete = autocompleteTask.Result;
            Assert.IsTrue(
                autocomplete.Completions.All(
                    c => c.Components.Username.Value.Contains(partial) 
                        || partial.Contains(c.Components.Username.Value)));
        }
    }
}
