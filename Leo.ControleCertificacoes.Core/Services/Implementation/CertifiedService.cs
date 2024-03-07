using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
using Leo.ControleCertificacoes.Core.Application.Mapper;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Enums;
using Leo.ControleCertificacoes.Core.Repository.Interfaces;
using Leo.ControleCertificacoes.Core.Services.Interfaces;

namespace Leo.ControleCertificacoes.Core.Services.Implementation
{
    public class CertifiedService : ICertifiedService
    {
        private readonly ICertifiedRepository _repository;
        private readonly IEmployeeService _employeeService;

        public CertifiedService(ICertifiedRepository repository, IEmployeeService employeeService)
        {
            _repository = repository;
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<CertifiedDto>> GetAll()
        {
            var certifieds = await _repository.GetAll();

            if (certifieds.Any())
            {
                return certifieds.Select(x => x.ToCertifiedDto());
            }

            return null;
        }

        public async Task<CertifiedDto> GetByIdAsync(Guid id)
        {
            Certified certified = await _repository.GetByIdAsync(id);

            if (certified is null)
            {
                return null;
            }

            return certified.ToCertifiedDto();
        }

        public async Task<CertifiedDto> GetByCodeAsync(int code)
        {
            Certified certified = await _repository.GetByCodeAsync(code);

            if (certified is null)
            {
                return null;
            }

            return certified.ToCertifiedDto();
        }

        public async Task<IEnumerable<CertifiedDto>> GetByEmployeeCode(int employeeCode)
        {
            var certifieds = await _repository.GetByEmployeeCode(employeeCode);

            if (certifieds is null)
            {
                return null;
            }

            return certifieds.Select(x => x.ToCertifiedDto());
        }

        public async Task<int> CountAsyncAsync()
        {
            return await _repository.CountAsyncAsync();
        }

        public async Task<CertifiedDto> InsertAsync(CertifiedCreateDto dto)
        {
            Certified certified = dto.ToCertified();

            if (await _repository.InsertAsync(certified) == 0)
            {
                return null;
            }

            await _employeeService.UpdateNumberOfCertifiedsAsync(dto.EmployeeId, EnumDataBaseOperation.INSERT);

            return await GetByIdAsync(certified.Id);
        }

        public async Task<CertifiedDto> UpdateAsync(CertifiedPatchDto dto)
        {
            Certified certified = await _repository.GetByIdAsync(dto.Id);

            if (certified is null)
            {
                return null;
            }

            certified.PatchCertified(dto);

            if (await _repository.UpdateAsync(certified) == 0)
            {
                return null;
            }

            return await GetByIdAsync(certified.Id);
        }

        public async Task<int> DeleteAsync(CertifiedDto dto)
        {
            Certified certified = await _repository.GetByIdAsync(dto.Id);

            if (certified is null)
            {
                return 0;
            }

            await _employeeService.UpdateNumberOfCertifiedsAsync(dto.EmployeeId, EnumDataBaseOperation.DELETE);

            return await _repository.DeleteAsync(certified);
        }
    }
}
