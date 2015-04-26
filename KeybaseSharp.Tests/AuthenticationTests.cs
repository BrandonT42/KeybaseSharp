using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenBonny.KeybaseSharp.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        private const string KnownUser = "kenbonny";
        private const string KnownUserFullName = "Ken Bonny";
        private const string UnknownUser = "bla";
        
        [TestMethod]
        public void Authenticate_Known_User()
        {
            var loginTask = KeybaseApi.Authenticate(KnownUser, "Fill in when necessary");
            Assert.IsNotNull(loginTask);

            var login = loginTask.Result;
            Assert.IsNotNull(login.User);
            Assert.AreEqual(0, login.Status.Code);
            Assert.AreEqual(KnownUserFullName, login.User.Profile.FullName);
        }
        
        [TestMethod]
        public void Authenticate_Known_User_Bad_Password()
        {
            var loginTask = KeybaseApi.Authenticate(KnownUser, "NotMyPassword");
            Assert.IsNotNull(loginTask);

            var login = loginTask.Result;
            Assert.IsNull(login.User);
            Assert.IsTrue(login.Status.Code != 0);
        }

        [TestMethod]
        public void Authenticate_Unknown_User()
        {
            var loginTask = KeybaseApi.Authenticate(UnknownUser, "DoesntMatter");
            Assert.IsNotNull(loginTask);

            try
            {
                var login = loginTask.Result;
                Assert.IsTrue(login.Status.Code != 0);
            }
            catch (Exception exception)
            {
                Assert.IsNotNull(exception);
            }
        }
    }
}