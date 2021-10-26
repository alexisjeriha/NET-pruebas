using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        public Plan()
        {
                
        }

        // Datos asociados al plan
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Especialidad asociada al plan
        public Especialidad Especialidad { get; set; }
    }
}
