using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GrpcCommonNet.Library.Unit
{
    /*
      Класс, содержащий вспомогательные криптографические функции.
      Создан: Карина, 26/07/2016
    Основные публичные методы:
    public static string getMd5Hash(string input) - вычисляет хэш-сумму строки по алгоритму MD5. Применяется при авторизации в программу, для шифрации введенного пароля 
    Пример вызова:
    dic.Add("_PW", Crypt.getMd5Hash(textBoxPassword.Text.Trim() + textBoxLogin.Text.Trim().ToUpper())); В качестве параметра передается текс из текстового поля "пароль"

    public static byte[] Encrypt(byte[] data, string password) - шифрует массив байтов паролем. Применяется при шифровании строковых данных. 
    Пример вызова:
    return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), password)); 

    public static string Encrypt(string data, string password)- шифрует строковых данных паролем (AES).

    public static byte[] Decrypt(byte[] data, string password) - расшифровывает закодированный массив байтов
    public static string Decrypt(string data, string password) - расшифровывает строку данных
    public static CryptoStream InternalDecrypt(byte[] data, string password) - Создает поток криптопреобразования (дешифровки) из массива байт и пароля (AES)
    Пример вызова:
    using (BinaryReader br = new BinaryReader(InternalDecrypt(data, password)))
    */

    /// <summary>
    /// Класс, содержащий вспомогательные криптографические функции
    /// </summary>
    public static class Crypt
    {
        /// <summary>
        /// Вычисление хеш-суммы входной строки по алгоритму MD5 
        /// </summary>
        /// <param name="input">строка</param>
        /// <returns>Строковое представление хеш-суммы в 16-ричной системе</returns>
        public static string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Функция шифрования массива байтов паролем (AES)
        /// </summary>
        /// <param name="data">Данные для зашифровывания</param>
        /// <param name="password">Пароль</param>
        /// <returns>Зашифрованный массив байтов</returns>
        public static byte[] Encrypt(byte[] data, string password)
        {
#pragma warning disable SYSLIB0022
            using (SymmetricAlgorithm sa = Rijndael.Create())
            using (ICryptoTransform ct = sa.CreateEncryptor((new PasswordDeriveBytes(password, null)).GetBytes(16), new byte[16]))
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
            {
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                return ms.ToArray();
            }
#pragma warning restore SYSLIB0022
        }

        /// <summary>
        /// Функция шифрования строковых данных паролем (AES)
        /// </summary>
        /// <param name="data">Строка для зашифровывания</param>
        /// <param name="password">Пароль</param>
        /// <returns>Зашифрованная строка</returns>
        public static string Encrypt(string data, string password)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), password));
        }

        /// <summary>
        /// Расшифровывает закодированный массив байтов
        /// </summary>
        /// <param name="data">Зашифрованный массив байтов</param>
        /// <param name="password">Пароль</param>
        /// <returns>Дешифрованный массив байтов</returns>
        public static byte[] Decrypt(byte[] data, string password)
        {
            using (BinaryReader br = new BinaryReader(InternalDecrypt(data, password)))
            {
                return br.ReadBytes((int)br.BaseStream.Length);
            }
        }

        /// <summary>
        /// Расшифровывает закодированную строку
        /// </summary>
        /// <param name="data">Строковые данные</param>
        /// <param name="password">Пароль</param>
        /// <returns>Расшифрованная строка</returns>
        public static string Decrypt(string data, string password)
        {
            string _result = String.Empty;

            try
            {
                Convert.FromBase64String(data);
            }
            catch
            {
                data = Encrypt(data, password);
            }
            finally
            {
                CryptoStream cs = InternalDecrypt(Convert.FromBase64String(data), password);
                StreamReader sr = new StreamReader(cs);

                _result = sr.ReadToEnd();
            }

            return _result;
        }

        /// <summary>
        /// Создает поток криптопреобразования (дешифровки) из массива байт и пароля (AES)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static CryptoStream InternalDecrypt(byte[] data, string password)
        {
#pragma warning disable SYSLIB0022
            using (SymmetricAlgorithm sa = Rijndael.Create())
            using (ICryptoTransform ct = sa.CreateDecryptor((new PasswordDeriveBytes(password, null)).GetBytes(16), new byte[16]))
            using (MemoryStream ms = new MemoryStream(data))
            {
                return new CryptoStream(ms, ct, CryptoStreamMode.Read);
            }
#pragma warning restore SYSLIB0022
        }
    }

}