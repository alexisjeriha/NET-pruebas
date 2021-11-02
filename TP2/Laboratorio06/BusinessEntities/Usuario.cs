using System;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        public String NombreUsuario { get; set; }

        public String Clave { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String EMail { get; set; }

        public bool Habilitado { get; set; }

    }
}
