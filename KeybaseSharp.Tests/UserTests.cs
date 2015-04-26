using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using KenBonny.KeybaseSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenBonny.KeybaseSharp.Tests
{
    [TestClass]
    public class UserTests
    {
        private const string KnownUser = "kenbonny";
        private const string KnwonTwitter = "bonny_ken";
        private const string KnownUserFullName = "Ken Bonny";
        private const string PartialUser = "kenbo";
        private const string UnknownUser = "bla";

        [TestMethod]
        public void Lookup_Test_Single_Known_User()
        {
            var lookupTask = User.LookupAsync(KnownUser);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.AreEqual(KnownUserFullName, lookup.Them.Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Single_Known_Identity()
        {
            var lookupTask = User.LookupAsync(KnwonTwitter, ProofType.Twitter);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 1);
            Assert.AreEqual(KnownUserFullName, lookup.Them.First().Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Multiple_Known_Users()
        {
            var lookupTask = User.LookupAsync(new[] {KnownUser, "ken"});
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 2);
            Assert.AreEqual(KnownUserFullName, lookup.Them.First().Profile.FullName);
            Assert.AreEqual("Ken Mather", lookup.Them.Last().Profile.FullName);
        }

        [TestMethod]
        public void Lookup_Test_Multiple_Known_Unknown_Users()
        {
            var lookupTask = User.LookupAsync(new[] {KnownUser, UnknownUser});
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsTrue(lookup.Them.Count() == 2);
            Assert.AreEqual(KnownUserFullName, lookup.Them.First().Profile.FullName);
            Assert.IsNull(lookup.Them.Last());
        }

        [TestMethod]
        public void Lookup_Test_Single_Unknown_User()
        {
            var lookup = User.LookupAsync(UnknownUser).Result;

            Assert.IsNotNull(lookup);
            Assert.AreEqual(205, lookup.Status.Code);
            Assert.AreEqual("NOT_FOUND", lookup.Status.Name);
            Assert.IsTrue(lookup.Them == null);
            Assert.IsFalse(string.IsNullOrEmpty(lookup.CsrfToken));
        }

        [TestMethod]
        public void Lookup_Test_Single_Unknown_Identity()
        {
            var lookupTask = User.LookupAsync(UnknownUser, ProofType.Twitter);
            Assert.IsNotNull(lookupTask);

            var lookup = lookupTask.Result;
            Assert.AreEqual(0, lookup.Status.Code);
            Assert.IsFalse(lookup.Them.Any());
        }

        [TestMethod]
        public void Autocomplete_Test()
        {

            var autocompleteTask = User.AutocompleteAsync(PartialUser);
            Assert.IsNotNull(autocompleteTask);

            var autocomplete = autocompleteTask.Result;
            Assert.IsTrue(
                autocomplete.Completions.All(
                    c => c.Components.Username.Value.Contains(PartialUser) 
                        || PartialUser.Contains(c.Components.Username.Value)));
        }

        [TestMethod]
        public void Key_Test_Known_User()
        {
            var key = User.Key(KnownUser).Result;

            Assert.IsFalse(string.IsNullOrWhiteSpace(key));
            Assert.IsTrue(key.Contains("BEGIN PGP PUBLIC KEY BLOCK"));
        }

        [TestMethod]
        public void Key_Test_Unknown_User()
        {
            try
            {
                var key = User.Key(UnknownUser).Result;
                Assert.AreEqual("SELF-SIGNED PUBLIC KEY NOT FOUND", key);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void Discover_Test_Known_User()
        {
            var identities = new Dictionary<ProofType, IEnumerable<string>>
            {
                {ProofType.Twitter, new[] {KnwonTwitter}}
            };
            var discoverTask = User.DiscoverAsync(identities);
            Assert.IsNotNull(discoverTask);

            var discover = discoverTask.Result;
            Assert.AreEqual(KnownUserFullName, discover.Matches.First().FullName);
            Assert.AreEqual(KnownUser, discover.Matches.First().Username);
        }

        [TestMethod]
        public void Discover_Test_Unknown_User()
        {
            var identities = new Dictionary<ProofType, IEnumerable<string>>
            {
                {ProofType.Twitter, new[] {UnknownUser}}
            };
            var discoverTask = User.DiscoverAsync(identities);
            Assert.IsNotNull(discoverTask);

            var discover = discoverTask.Result;
            Assert.AreEqual(0, discover.Matches.Count());
            Assert.IsFalse(discover.Matches.Any());
        }

        [TestMethod]
        public void DiscoverUsernames_Test_Known_User()
        {
            var identities = new Dictionary<ProofType, IEnumerable<string>>
            {
                {ProofType.Twitter, new[] {KnwonTwitter}}
            };
            var discoverTask = User.DiscoverUsernamesAsync(identities);
            Assert.IsNotNull(discoverTask);

            var discover = discoverTask.Result;
            Assert.AreEqual(KnownUser, discover.Matches.First());
        }

        [TestMethod]
        public void Discover_Usernames_Test_Unknown_User()
        {
            var identities = new Dictionary<ProofType, IEnumerable<string>>
            {
                {ProofType.Twitter, new[] {UnknownUser}}
            };
            var discoverTask = User.DiscoverUsernamesAsync(identities);
            Assert.IsNotNull(discoverTask);

            var discover = discoverTask.Result;
            Assert.AreEqual(0, discover.Matches.Count());
            Assert.IsFalse(discover.Matches.Any());
        }
    }
}
