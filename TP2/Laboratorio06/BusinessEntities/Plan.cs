namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private Especialidad especialidad;
        public Plan()
        {
            Especialidad = new Especialidad();
        }

        // Datos asociados al plan
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Especialidad asociada al plan
        public Especialidad Especialidad 
        {
            get { return especialidad; }
            set { especialidad = value; }
        }
        public int IDespecialidad
        {
            get { return Especialidad.Id; }
        }
    }
}
