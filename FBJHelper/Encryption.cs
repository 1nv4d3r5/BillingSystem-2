using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FBJHelper
{
    /// <summary>
    /// 加密
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <param name="skey">密钥，且必须为8位</param>
        /// <returns>以Base64格式返回的加密字符串</returns>
        public static string DESEncrypt(string pToEncrypt, string skey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = Encoding.UTF8.GetBytes(skey.Substring(0, 8));
                des.IV = Encoding.UTF8.GetBytes(skey.Substring(0, 8));
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
            catch
            {
                return pToEncrypt;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static string DESEdcrypt(string pToDecrypt, string skey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(skey);
                des.IV = Encoding.UTF8.GetBytes(skey);
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray,0,inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// MD5 加密字符串
        /// </summary>
        /// <param name="rawPass">源字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5Encoding(string rawPass)
        {
            //创建MD5类的默认实例：MD5CryptoServiceProvider
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                //以十六进制格式格式化
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// MD5盐值加密
        /// </summary>
        /// <param name="rawwPass">源字符串</param>
        /// <param name="salt">盐值</param>
        /// <returns>加密后字符串</returns>
        public static string MD5Encoding(string rawwPass, object salt)
        {
            if (salt == null) return rawwPass;
            return MD5Encoding(rawwPass +"{"+salt.ToString()+"}");
        }


        // Verify a hash against a string
        public static bool VerifyMd5Hash(string input,string hash)
        {
            string hashOfInput = MD5Encoding(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 对MD5加密后的密文进行签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">MD5加密后的密文</param>
        /// <returns></returns>
        public static string SignatureFormatter(string p_strKeyPrivate,string m_strHashbyteSignature)
        {
            byte[] rgbHash = Convert.FromBase64String(m_strHashbyteSignature);
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPrivate);
            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("MD5");
            byte[] inArray = formatter.CreateSignature(rgbHash);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="p_strHashbyteDeformatter">待验证的用户名</param>
        /// <param name="p_strDeformatterData">注册码</param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string p_strKeyPublic,string p_strHashbyteDeformatter,string p_strDeformatterData)
        {
            try
            {
                byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
                RSACryptoServiceProvider key = new RSACryptoServiceProvider();
                key.FromXmlString(p_strKeyPublic);
                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("MD5");
                byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);
                if (deformatter.VerifySignature(rgbHash, rgbSignature))
                {
                    return true;
                }
                return false;
            }
            catch 
            {
                return false ;
            }
        }
        
        #region 安全哈希算法，主要适用于数字签名（没有解密）
        public static string SHA1Encrypt(string input)
        {
            byte[] tmpByte=Encoding.Default.GetBytes(input);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            tmpByte = sha1.ComputeHash(tmpByte);
            sha1.Clear();
            StringBuilder enText = new StringBuilder();
            foreach (byte iByte in tmpByte)
            {
                enText.AppendFormat("{0:x2}",iByte);
            }
            return enText.ToString();

        }

        private static byte[] GetKeyByteArray(string input)
        {
            ASCIIEncoding asc = new ASCIIEncoding();
            int len = input.Length;
            byte[] tmpByte = new byte[len - 1];
            tmpByte = asc.GetBytes(input);
            return tmpByte;
        }

        private static string GetStringValue(byte[]Byte)
        {
            string tmpString = string.Empty;
            for (int i = 0; i < Byte.Length; i++)
            {
                tmpString += Byte[i].ToString();
            }
            return tmpString;
        }
        #endregion

        #region RSA加密、解密
        /*RSA加密算法是一种非对称加密算法，
         * 所谓的非对称加密，就是指加密和解密使用不同的密钥的一类加密算法*/
        public static string RSAEncrypt(string xmlPublicKey,string m_strEncryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPublicKey);
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
                str2 = Convert.ToBase64String(provider.Encrypt(bytes,false));
            }
            catch (Exception e)
            {
                throw e;
            }
            return str2;
        }

        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPrivateKey);
                byte[] rgb = Convert.FromBase64String(m_strDecryptString);
                byte[] buffer2 = provider.Decrypt(rgb,false);
                str2 = new UnicodeEncoding().GetString(buffer2);
            }
            catch (Exception e)
            {
                throw e;
            }
            return str2;
        }
        #endregion
    }
}
