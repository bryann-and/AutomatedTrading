using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities.System
{
    public class Usuario
    {
        public long? Codigo { get; set; }

        public long? CodigoPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
