using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface ICertifiedService
    {
        Task<CertifiedReadDto> GetByIdAsync(Guid id);

        Task<CertifiedReadDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<int> InsertAsync(CertifiedCreateDto dto);

        Task<int> UpdateAsync(CertifiedReadDto dto);

        Task<int> DeleteAsync(CertifiedReadDto dto);
    }
}
