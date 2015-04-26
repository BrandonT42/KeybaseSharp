using System;
using System.Security.Cryptography;
using CryptSharp;
using CryptSharp.Utility;
using KenBonny.KeybaseSharp.Utility;

namespace KenBonny.KeybaseSharp.Model.Authentication
{
    public class Password
    {
        private readonly string _passwordHash;

        /// <summary>
        /// Hashes an unhashed password.
        /// </summary>
        /// <param name="unhashedPassword">The unhashed password.</param>
        /// <param name="salt">The salt that shall be used to hash the password.</param>
        public Password(string unhashedPassword, Salt salt)
        {
            var scryptHash = CreateScryptHash(unhashedPassword, salt.Token).SubArray(192);
            _passwordHash = CreateHmacPasswordHash(scryptHash, salt.Session);
        }

        /// <summary>
        /// Return the hashed password.
        /// </summary>
        /// <returns>The hashed password.</returns>
        public override string ToString()
        {
            return _passwordHash;
        }

        private static byte[] CreateScryptHash(string unhashedPassword, string salt)
        {
            const int n = 32768; // 2^15
            const int r = 8;
            const int p = 1;
            const int derivedKeyLength = 224;

            var key = StringToByteArray(unhashedPassword);
            var bytesFromSalt = StringToByteArray(salt);

            return SCrypt.ComputeDerivedKey(key, bytesFromSalt, n, r, p, null, derivedKeyLength);
        }

        private static string CreateHmacPasswordHash(byte[] hash, string session)
        {
            var hmac = new HMACSHA512(hash);
            var base64Session = Convert.FromBase64String(session);
            var hmacHash = hmac.ComputeHash(base64Session);

            return ByteArrayToString(hmacHash);
        }

        private static byte[] StringToByteArray(string text)
        {
            var bytes = new byte[text.Length * sizeof(char)];
            Buffer.BlockCopy(text.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string ByteArrayToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}