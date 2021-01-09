using System;

namespace SistemaMySQL.Entidades
{
    public class Vendas
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Dt_venda { get; set; }
        public int Id_cliente { get; set; }
    }
}
