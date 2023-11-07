namespace AutomacaoERP.API.Models
{
    public class ClientesCadastro
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<Cliente>? clientes_cadastro { get; set; }
    }
}
