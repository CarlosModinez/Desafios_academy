using System;
using System.Security.Cryptography;


namespace Desafios_academy.Controllers
{
    public class Cryptography
    {
        public const int iterations = 100000; // The number of times to encrypt the password - change this
        public const int saltByteSize = 64; // the salt size - change this
        public const int hashByteSize = 128; // the final hash - change this

        public string CreatePasswordHash_Single(string password)
        {
           
            BouncyCastleHashing mainHashingLib = new BouncyCastleHashing();

            byte[] saltBytes = mainHashingLib.CreateSalt(saltByteSize);
            string saltString = Convert.ToBase64String(saltBytes);

            return mainHashingLib.PBKDF2_SHA256_GetHash(password, saltString, iterations, hashByteSize);

        }

        public bool Validate(string password)
        {
            
            BouncyCastleHashing mainHashingLib = new BouncyCastleHashing();

            byte[] saltBytes = mainHashingLib.CreateSalt(saltByteSize);
            string saltString = Convert.ToBase64String(saltBytes);

            string pwdHash = mainHashingLib.PBKDF2_SHA256_GetHash(password, saltString, iterations, hashByteSize);

            return mainHashingLib.ValidatePassword(password, saltBytes, iterations, hashByteSize, Convert.FromBase64String(pwdHash));

        }
    }
}
