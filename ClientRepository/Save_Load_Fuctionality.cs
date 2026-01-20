using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ClientRepository
{
    internal class Save_Load_Fuctionality
    {
        public enum FileFormat
        {
            TXT,  //text file
            JSON  //structured text
        }

        private static readonly byte[] Key =
            Encoding.UTF8.GetBytes("1234567890123456");  //strings to 16 bytes

        private static readonly byte[] IV =
            Encoding.UTF8.GetBytes("6543210987654321");  //strings to 16 bytes

        public static void Save(string filePath, string data, FileFormat format)
        {
            string formattedData;

            switch (format)
            {
                case FileFormat.TXT:
                    formattedData = data;
                    break;
                case FileFormat.JSON:
                    formattedData = JsonSerializer.Serialize(data);
                    break;
                default:
                    throw new NotSupportedException();
            }

            byte[] encrypted = Encrypt(formattedData);
            File.WriteAllBytes(filePath, encrypted);
        }

        public static string Load(string filePath, FileFormat format)
        {
            byte[] encrypted = File.ReadAllBytes(filePath);
            string decrypted = Decrypt(encrypted);

            if (format == FileFormat.JSON)
                return JsonSerializer.Deserialize<string>(decrypted);

            return decrypted;
        }

        private static byte[] Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();  //advanced encryption standard
            aes.Key = Key;  //password 
            aes.IV = IV;  //encryption more random

            using ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        }

        private static string Decrypt(byte[] cipherText)
        {
            using Aes aes = Aes.Create();  //decryption 
            aes.Key = Key;
            aes.IV = IV;

            using ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}