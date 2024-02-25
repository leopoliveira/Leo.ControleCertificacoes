namespace Leo.ControleCertificacoes.Core.Application.Dtos.Base
{
    public record BaseDtoWithIdAndCorde
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
    }
}
