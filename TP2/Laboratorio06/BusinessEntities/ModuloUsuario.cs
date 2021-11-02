namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        public int IdUsuario { get; set; }

        public int IdModulo { get; set; }

        public bool PermiteAlta { get; set; }

        public bool PermiteBaja { get; set; }

        public bool PermiteModificacion { get; set; }

        public bool PermiteConsulta { get; set; }


    }
}
