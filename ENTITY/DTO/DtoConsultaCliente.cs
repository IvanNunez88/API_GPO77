
namespace ENTITY.DTO
{
    public record DtoConsultaCliente
    {
        public int IdCliente { get; set; } = 0;
        public string Cliente { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string FecRegistro { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;

    }
}
