using System;
using System.Collections.Generic;

namespace Api_redes.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
