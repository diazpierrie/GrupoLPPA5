﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo5.Entities.Models
{
    public class Rol : IdentityBase
    {
        public string Nombre { get; set; }

        public virtual ICollection<User> Usuario { get; set; }
    }
}
