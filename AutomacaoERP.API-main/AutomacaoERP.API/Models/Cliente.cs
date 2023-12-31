﻿namespace AutomacaoERP.API.Models
{
    // Cliente myDeserializedClass = JsonConvert.DeserializeObject<Cliente>(myJsonResponse);

    public class Cliente
    {
        public long codigo_cliente_omie { get; set; }
        public string? codigo_cliente_integracao { get; set; }
        public string? razao_social { get; set; }
        public string? cnpj_cpf { get; set; }
        public string? nome_fantasia { get; set; }
        public string? telefone1_ddd { get; set; }
        public string? telefone1_numero { get; set; }
        public string? contato { get; set; }
        public string? endereco { get; set; }
        public string? endereco_numero { get; set; }
        public string? bairro { get; set; }
        public string? complemento { get; set; }
        public string? estado { get; set; }
        public string? cidade { get; set; }
        public string? cep { get; set; }
        public string? codigo_pais { get; set; }
        public string? separar_endereco { get; set; }
        public string? pesquisar_cep { get; set; }
        public string? telefone2_ddd { get; set; }
        public string? telefone2_numero { get; set; }
        public string? fax_ddd { get; set; }
        public string? fax_numero { get; set; }
        public string? email { get; set; }
        public string? homepage { get; set; }
        public string? inscricao_estadual { get; set; }
        public string? inscricao_municipal { get; set; }
        public string? inscricao_suframa { get; set; }
        public string? optante_simples_nacional { get; set; }
        public string? tipo_atividade { get; set; }
        public string? cnae { get; set; }
        public string? produtor_rural { get; set; }
        public string? contribuinte { get; set; }
        public string? observacao { get; set; }
        public string? obs_detalhadas { get; set; }
        public string? recomendacao_atraso { get; set; }
        public List<Tag>? tags { get; set; }
        public string? pessoa_fisica { get; set; }
        public string? exterior { get; set; }
        public string? logradouro { get; set; }
        public string? importado_api { get; set; }
        public string? bloqueado { get; set; }
        public string? cidade_ibge { get; set; }
        public long valor_limite_credito { get; set; }
        public string? bloquear_faturamento { get; set; }
        public Recomendacoes? recomendacoes { get; set; }
        public EnderecoEntrega? enderecoEntrega { get; set; }
        public string? nif { get; set; }
        public string? documento_exterior { get; set; }
        public string? inativo { get; set; }
        public DadosBancarios? dadosBancarios { get; set; }
        public List<object>? caracteristicas { get; set; }
        public string? enviar_anexos { get; set; }
        public Info? info { get; set; }
        public string? bloquear_exclusao { get; set; }
    }

    public class Tag
    {
        public string? tag { get; set; }
    }

    public class DadosBancarios
    {
        public string? agencia { get; set; }
        public string? codigo_banco { get; set; }
        public string? conta_corrente { get; set; }
        public string? doc_titular { get; set; }
        public string? nome_titular { get; set; }
        public string? transf_padrao { get; set; }
    }

    public class EnderecoEntrega
    {
    }

    public class Recomendacoes
    {
        public long codigo_transportadora { get; set; }
        public string? gerar_boletos { get; set; }
    }

}
