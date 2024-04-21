namespace Soldi.Core.Entities
{
    public sealed class Fatura:Entity
    {
        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid CartaoId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string? Observacoes { get; private set; }
        
    }



}
