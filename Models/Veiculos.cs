﻿using System;
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

        public long Handle { get; set; }

        //[Required]
        public string Placa { get; set; }
        public string TipoDoCarro { get; set; }

        public int MotoristaId { get; set; }
        public Usuarios Motorista { get; set; }

        public bool Ativo { get; set; }

        public IList<Tickets> tickets { get; set; }


        public Veiculos()
        {
            Ativo = true;
        }

        public Veiculos(string placa, string tipoDoCarro)
        { 

            Placa = placa;
            TipoDoCarro = tipoDoCarro;
            Ativo = true;
        }
    }
}