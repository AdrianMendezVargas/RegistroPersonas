﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPersona.Entidades {
    public class Persona {

        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }

        public Persona() {

            PersonaId = 0;
            Nombre = "";

        }

    }
}
