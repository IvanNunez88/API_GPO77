namespace ENTITY
{
    public record CLIENTE
    {
        public int? IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string APaterno { get; set; } = string.Empty;
        public string AMaterno { get; set; } = string.Empty;
        public string RCF { get; set; } = string.Empty;
        public bool? Estatus { get; set; }

    }
}
