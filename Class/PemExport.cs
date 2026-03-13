using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;

namespace MifareTool.Class
{
    public static class PemExport
    {
        // PKCS#8 "BEGIN PRIVATE KEY" 형식
        public static string ExportPrivateKeyPem(RSA rsa)
        {
            if (rsa == null) throw new ArgumentNullException(nameof(rsa));

            AsymmetricCipherKeyPair keyPair = DotNetUtilities.GetRsaKeyPair(rsa);

            using (var sw = new StringWriter())
            {
                var pw = new PemWriter(sw);
                pw.WriteObject(keyPair.Private); // private key
                pw.Writer.Flush();
                return sw.ToString();
            }
        }

        // X.509 SubjectPublicKeyInfo "BEGIN PUBLIC KEY" 형식
        public static string ExportPublicKeyPem(RSA rsa)
        {
            if (rsa == null) throw new ArgumentNullException(nameof(rsa));

            AsymmetricKeyParameter publicKey = DotNetUtilities.GetRsaPublicKey(rsa);

            using (var sw = new StringWriter())
            {
                var pw = new PemWriter(sw);
                pw.WriteObject(publicKey); // public key
                pw.Writer.Flush();
                return sw.ToString();
            }
        }
    }
}
