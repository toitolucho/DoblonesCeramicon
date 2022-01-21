using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WFADoblones20.Librerias
{
    class Seguridad
    {
        /// <summary>
        /// metodo estatico para encriptar un string de cualquier tamaño
        /// </summary>
        /// <param name="data">el string a encriptar</param>
        /// <param name="fileName">el nombre del archivo donde se guardara el archivo encriptado</param>
        /// <param name="Key">primer parametro para la encriptacion - la llave con la que se encriptara</param>
        /// <param name="IV">segundo parametro para la encriptacion</param>
        public static void encriptar(String data, String fileName, byte[] Key, byte[] IV)
        {
            try
            {
                FileStream fStream = File.Open(fileName, FileMode.OpenOrCreate);
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);
                StreamWriter sWriter = new StreamWriter(cStream);
                sWriter.WriteLine(data);
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Ocurrio un error: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Ocurrio un error al acceder al archivo: {0}", e.Message);
            }
        }
        /// <summary>
        /// metodo para desencriptar un string de cualquier tamaño
        /// </summary>
        /// <param name="fileName">el nombre del archivo del que se quiere desemcriptar</param>
        /// <param name="Key">primer parametro para la desencriptacion</param>
        /// <param name="IV">segundo parametro para la desencriptacion</param>
        /// <returns></returns>
        public static string desencriptar(String fileName, byte[] Key, byte[] IV)
        {
            try
            {
                FileStream fStream = File.Open(fileName, FileMode.OpenOrCreate);
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);
                StreamReader sReader = new StreamReader(cStream);
                string val = sReader.ReadToEnd();
                sReader.Close();
                cStream.Close();
                fStream.Close();
                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Ocurrio un error en la desencriptacion: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Ocurrio un error al acceder al archivo: {0}", e.Message);
                return null;
            }
        }

        public static void encriptarFile(string path , string codigoSeguridad) {
            StreamReader sReader = new StreamReader(path);
            String data = sReader.ReadToEnd();
            sReader.Close();
            string codigo = "";
            for (int i = 0; i < codigoSeguridad.Length; i++)
            {
                if (codigoSeguridad[i] != ' ')
                {
                    codigo += codigoSeguridad[i];
                }
            }
            string llave = codigo;
            while (llave.Length <= 24)
            {
                llave += codigoSeguridad;
            }
            llave = llave.Remove(24);
            string simetria = codigoSeguridad;
            while (simetria.Length <= 8)
            {
                simetria += codigoSeguridad;
            }
            simetria = simetria.Remove(8);
            byte[] key = Encoding.ASCII.GetBytes(llave);
            byte[] iv = Encoding.ASCII.GetBytes(simetria);
            encriptar(data, path, key, iv);
        }

        public static void desencriptarFile(string path, string codigoSeguridad) {
            string llave = codigoSeguridad;
            while (llave.Length <= 24)
            {
                llave += codigoSeguridad;
            }
            llave = llave.Remove(24);
            string simetria = codigoSeguridad;
            while (simetria.Length <= 8)
            {
                simetria += codigoSeguridad;
            }

            simetria = simetria.Remove(8);
            byte[] key = Encoding.ASCII.GetBytes(llave);
            byte[] iv = Encoding.ASCII.GetBytes(simetria);
            string data = desencriptar(path, key, iv);
            StreamWriter sWriter = new StreamWriter(path);
            sWriter.WriteLine(data);
            sWriter.Close();
        }

    }
}
