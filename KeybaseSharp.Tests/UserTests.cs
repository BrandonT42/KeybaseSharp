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
        public void Lookup_Test_Single_Known_User()
        {
            var lookupTask = User.LookupAsync("kenbonny");
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.AreEqual("Ken Bonny", lookup.Them.Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Single_Known_Identity()
        {
            var lookupTask = User.LookupAsync("bonny_ken", ProofType.Twitter);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 1);
            Assert.AreEqual("Ken Bonny", lookup.Them.First().Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Multiple_Known_Users()
        {
            var lookupTask = User.LookupAsync(new[] {"kenbonny", "ken"});
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 2);
            Assert.AreEqual("Ken Bonny", lookup.Them.First().Profile.FullName);
            Assert.AreEqual("Ken Mather", lookup.Them.Last().Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Multiple_Known_Unknown_Users()
        {
            var lookupTask = User.LookupAsync(new[] {"kenbonny", "bla"});
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 2);
            Assert.AreEqual("Ken Bonny", lookup.Them.First().Profile.FullName);
            Assert.IsNull(lookup.Them.Last());
        }

        [TestMethod]
        public void Lookup_Test_Single_Unknown_User()
        {
            var lookup = User.LookupAsync("bla").Result;

            Assert.IsNotNull(lookup);
            Assert.AreEqual(205, lookup.Status.Code);
            Assert.AreEqual("NOT_FOUND", lookup.Status.Name);
            Assert.IsTrue(lookup.Them == null);
            Assert.IsFalse(string.IsNullOrEmpty(lookup.CsrfToken));
        }

        [TestMethod]
        public void Lookup_Test_Single_Unknown_Identity()
        {
            var lookupTask = User.LookupAsync("bla", ProofType.Twitter);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsFalse(lookup.Them.Any());
        }

        [TestMethod]
        public void Autocomplete_Test()
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
