using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Model
{
    public class Veiculos
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int Handle { get; set; }

        public string Placa { get; set; }
        public string TipoDoCarro { get; set; }

        public Usuarios Motorista { get; set; }

        public bool Ativo { get; set; }

        public IList<Tickets> tickets { get; set; }



        public Veiculos(string placa, string tipoDoCarro)
        { 
            this.Placa = placa;
            this.TipoDoCarro = tipoDoCarro;
            Ativo = true;

        }
    }
}
