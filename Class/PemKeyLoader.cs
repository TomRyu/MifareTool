using System;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace MifareTool.Class
{
    public static class PemKeyLoader
    {
        public static RSA LoadRsaPublicKeyFromPem(string pemPath)
        {
            if (!File.Exists(pemPath))
                throw new FileNotFoundException("public_key.pem not found", pemPath);

            using (var reader = File.OpenText(pemPath))
            {
                var pemReader = new PemReader(reader);
                object obj = pemReader.ReadObject();

                if (obj is AsymmetricKeyParameter akp)
                {
                    // BEGIN PUBLIC KEY or BEGIN RSA PUBLIC KEY
                    var rsaKey = (RsaKeyParameters)akp;
                    RSAParameters rp = DotNetUtilities.ToRSAParameters(rsaKey);

                    var rsa = RSA.Create();
                    rsa.ImportParameters(rp);
                    return rsa;
                }

                throw new InvalidOperationException("PEM에서 공개키를 읽지 못했습니다.");
            }
        }
    }

}
