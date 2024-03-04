namespace Leo.ControleCertificacoes.Core.Application.Dtos.Base
{
    public record BaseDtoWithIdAndCode
    {
        public Guid Id { get; set; }

        public int Code { get; set; }
    }
}
