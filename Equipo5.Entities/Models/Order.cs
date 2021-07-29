using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Equipo5.Entities.Models
{
    public class Order : IdentityBase
    {
        public Order()
        {
            FechaInicio = DateTime.Now;
        }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public string TipoOrder { get; set; }
        public virtual ICollection<OrderDetail> DetalleOrder { get; set; }
        public virtual User Usuario { get; set; }
    }
}
