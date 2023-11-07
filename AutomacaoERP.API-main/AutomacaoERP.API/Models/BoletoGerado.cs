namespace AutomacaoERP.API.Models
{
    public class BoletoGerado
    {
        public string? cLinkBoleto { get; set; }
        public string? cCodStatus { get; set; }
        public string? cDesStatus { get; set; }
        public string? dDtEmBol { get; set; }
        public string? cNumBoleto { get; set; }
        public string? cCodBarras { get; set; }
        public long nPerJuros { get; set; }
        public long nPerMulta { get; set; }
        public string? cNumBancario { get; set; }
        public string? dDescontoCond1 { get; set; }
        public long vDescontoCond1 { get; set; }
        public string? dDescontoCond2 { get; set; }
        public long vDescontoCond2 { get; set; }
        public string? dDescontoCond3 { get; set; }
        public long vDescontoCond3 { get; set; }
    }
}
