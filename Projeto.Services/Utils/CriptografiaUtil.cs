using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Projeto.Services.Utils
{
    public class CriptografiaUtil
    {
        //método para retornar a senha encriptada em MD5..
        public static string Encriptar(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //converter o valor recebido para byte[]
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(valor);

            //aplicar a criptografia MD5..
            byte[] hash = md5.ComputeHash(senhaEmBytes);

            //retornar o hash da criptografia em formato string..
            string resultado = string.Empty;

            foreach(byte item in hash)
            {
                //converter para string em formato 
                resultado += item.ToString("X2"); //X2 -> HEXADECIMAL
            }

            return resultado; //retornando..
        }
    }
}