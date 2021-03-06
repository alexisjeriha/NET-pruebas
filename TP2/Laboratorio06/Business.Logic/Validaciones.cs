using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class Validaciones
    {
        public static bool EsMailValido(string mail)
        {
            Boolean val = true;
            String expresion;
            expresion = @"^[^@\s]+@[^@\s]+.[^@\s]+$";
            if (Regex.IsMatch(mail, expresion))
            {
                if (Regex.Replace(mail, expresion, String.Empty).Length == 0)
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            else
            {
                val = false;
            }
            return val;

        }

        public static bool ValidaPass(string pass, string confPass)
        {
            Boolean val = true;

            if (string.Equals(pass, confPass))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            return val;
        }

        public static bool EsAlfanumerico(string password)
        {
            Boolean val = true;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(password))
            {
                if (r.Replace(password, String.Empty).Length == 0)
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }

            else
            {
                val = false;
            }
            return val;
        }
    }
}
