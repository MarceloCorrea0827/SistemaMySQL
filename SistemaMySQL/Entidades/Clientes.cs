﻿using System;

namespace SistemaMySQL.Entidades
{
    class Clientes
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
