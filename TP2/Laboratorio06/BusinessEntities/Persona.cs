﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {

        public Persona()
        {
            Plan = new Plan();
        }

        // Datos particulares de la persona
        public int IdPersona { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Legajo { get; set; }
        public int Tipo { get; set; }

        //Plan asociado a la persona
        public Plan Plan { get; set; }


    }
}