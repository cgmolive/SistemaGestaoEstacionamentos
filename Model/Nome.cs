﻿using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos
{
    public class Nome
    {
        public string  Dados { get; set; }

        public Nome(string Dados)
        {
            if (Dados == null)
                throw new CampoInvalidoException();

            else if (Regex.IsMatch(Dados, (@"[^a-zA-Z0-9]")))
            {
                throw new CampoInvalidoException("Caracteres especiais não devem ser aceitos!");
            }

            else
            {
                this.Dados = Dados;
            }

        }
    }
}

