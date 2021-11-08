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
        //public int ID { get; set; }
        public string Descripcion { get; set; }

        // Especialidad asociada al plan
        public Especialidad Especialidad 
        {
            get { return especialidad; }
            set { especialidad = value; }
        }
        public int IDespecialidad
        {
            get { return Especialidad.ID; }
        }
        public string DescEspecialidad
        {
            get { return Especialidad.Descripcion; }
        }
    }
}
