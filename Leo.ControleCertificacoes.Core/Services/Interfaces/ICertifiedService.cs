using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface ICertifiedService
    {
        Task<CertifiedDto> GetByIdAsync(Guid id);

        Task<CertifiedDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<int> InsertAsync(CertifiedCreateDto dto);

        Task<int> UpdateAsync(CertifiedDto dto);

        Task<int> DeleteAsync(CertifiedDto dto);
    }
}
