﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soldi.Core.Entities
{
    public class Usuario:Entity
    {
        public string? Nome { get; private set; }

        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }


        public IReadOnlyCollection<Cartao>? Cartao { get; set;}
    }
}