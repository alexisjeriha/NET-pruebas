using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Usuario : BusinessEntity
    {
        private String _NombreUsuario;

        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private String _Clave;

        public String Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private String _Nombre;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private String _Apellido;

        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private String _EMail;

        public String EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        private bool _Habilitado;

        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }






    }
}
