﻿using System;

namespace SistemaMySQL.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
