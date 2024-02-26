using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
using Leo.ControleCertificacoes.Core.Application.Mapper;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;
using Leo.ControleCertificacoes.Core.Services.Interfaces;

namespace Leo.ControleCertificacoes.Core.Services.Implementation
{
    public class CertifiedService : ICertifiedService
    {
        private readonly ICertifiedRepository _repository;

        public CertifiedService(ICertifiedRepository repository)
        {
            _repository = repository;
        }

        public async Task<CertifiedReadDto> GetByIdAsync(Guid id)
        {
            Certified certified = await _repository.GetByIdAsync(id);

            if (certified is null)
            {
                return null;
            }

            return certified.ToCertifiedReadDto();
        }

        public async Task<CertifiedReadDto> GetByCodeAsync(int code)
        {
            Certified certified = await _repository.GetByCodeAsync(code);

            if (certified is null)
            {
                return null;
            }

            return certified.ToCertifiedReadDto();
        }

        public async Task<int> CountAsyncAsync()
        {
            return await _repository.CountAsyncAsync();
        }

        public async Task<int> InsertAsync(CertifiedCreateDto dto)
        {
            Certified certified = dto.ToCertified();

            return await _repository.InsertAsync(certified);
        }

        public async Task<int> UpdateAsync(CertifiedReadDto dto)
        {
            Certified certified = await _repository.GetByIdAsync(dto.Id);

            if (certified is null)
            {
                return 0;
            }

            certified = dto.ToCertified();

            return await _repository.UpdateAsync(certified);
        }

        public async Task<int> DeleteAsync(CertifiedReadDto dto)
        {
            Certified certified = await _repository.GetByIdAsync(dto.Id);

            if (certified is null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(certified);
        }
    }
}
