using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Vagas
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Handle { get; set; }
        public string TipoDaVaga { get; set; }
        public string LocalDaVaga { get; set; }
        public int EstacionamentoId { get; set; }

        public Vagas(string TipoDaVaga, string LocalDaVaga)
        {
            this.TipoDaVaga = TipoDaVaga;
            this.LocalDaVaga = LocalDaVaga;
        }
        public Vagas()
        {

        }
    }
}
