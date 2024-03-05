using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;

namespace Leo.ControleCertificacoes.Core.Services.Interfaces
{
    public interface ICertifiedService
    {
        Task<IEnumerable<CertifiedDto>> GetAll();

        Task<CertifiedDto> GetByIdAsync(Guid id);

        Task<CertifiedDto> GetByCodeAsync(int code);

        Task<int> CountAsyncAsync();

        Task<CertifiedDto> InsertAsync(CertifiedCreateDto dto);

        Task<CertifiedDto> UpdateAsync(CertifiedPatchDto dto);

        Task<int> DeleteAsync(CertifiedDto dto);
    }
}
