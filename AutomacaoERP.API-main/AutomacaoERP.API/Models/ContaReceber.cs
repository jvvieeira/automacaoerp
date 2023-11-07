namespace AutomacaoERP.API.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<ContaReceber>(myJsonResponse);

    using System;
    using System.Collections.Generic;

    public class Boleto
    {
        public string? cGerado { get; set; }
        public string? cNumBancario { get; set; }
        public string? cNumBoleto { get; set; }
        public string? dDtEmBol { get; set; }
        public long nPerJuros { get; set; }
        public long nPerMulta { get; set; }
    }

    public class Categoria
    {
        public string? codigo_categoria { get; set; }
        public long percentual { get; set; }
        public double? valor { get; set; }
    }

    public class ContaReceberCadastro
    {
        public Boleto? boleto { get; set; }
        public List<Categoria>? categorias { get; set; }
        public string? codigo_barras_ficha_compensacao { get; set; }
        public string? codigo_categoria { get; set; }
        public long codigo_cliente_fornecedor { get; set; }
        public string? codigo_lancamento_integracao { get; set; }
        public long codigo_lancamento_omie { get; set; }
        public string? codigo_tipo_documento { get; set; }
        public string? data_emissao { get; set; }
        public string? data_previsao { get; set; }
        public string? data_registro { get; set; }
        public string? data_vencimento { get; set; }
        public List<object>? distribuicao { get; set; }
        public long id_conta_corrente { get; set; }
        public string? id_origem { get; set; }
        public long nCodPedido { get; set; }
        public string? numero_documento_fiscal { get; set; }
        public string? numero_parcela { get; set; }
        public string? numero_pedido { get; set; }
        public string? operacao { get; set; }
        public string? retem_cofins { get; set; }
        public string? retem_csll { get; set; }
        public string? retem_inss { get; set; }
        public string? retem_ir { get; set; }
        public string? retem_iss { get; set; }
        public string? retem_pis { get; set; }
        public string? status_titulo { get; set; }
        public string? tipo_agrupamento { get; set; }
        public double valor_documento { get; set; }
        public Info? info { get; set; }
    }

    public class ContaReceber
    {
        public long pagina { get; set; }
        public long total_de_paginas { get; set; }
        public long registros { get; set; }
        public long total_de_registros { get; set; }
        public List<ContaReceberCadastro>? conta_receber_cadastro { get; set; }
    }



}
