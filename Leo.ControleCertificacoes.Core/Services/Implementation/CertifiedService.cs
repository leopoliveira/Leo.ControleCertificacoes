﻿using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
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

        public async Task<CertifiedDto> GetByIdAsync(Guid id)
        {
            Certified certified = await _repository.GetByIdAsync(id);

            if (certified is null)
            {
                return null;
            }

            return certified.ToCertifiedReadDto();
        }

        public async Task<CertifiedDto> GetByCodeAsync(int code)
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

        public async Task<CertifiedDto> InsertAsync(CertifiedCreateDto dto)
        {
            Certified certified = dto.ToCertified();

            if (await _repository.InsertAsync(certified) == 0)
            {
                return null;
            }

            return await GetByIdAsync(certified.Id);
        }

        public async Task<CertifiedDto> UpdateAsync(CertifiedDto dto)
        {
            Certified certified = await _repository.GetByIdAsync(dto.Id);

            if (certified is null)
            {
                return null;
            }

            certified = dto.ToCertified();

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

            return await _repository.DeleteAsync(certified);
        }
    }
}
