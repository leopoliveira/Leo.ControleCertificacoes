using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Helpers;

namespace Leo.ControleCertificacoes.Core.Application.Mapper
{
    public static class CertifiedMapper
    {
        #region "Certified"

        public static Certified ToCertified(this CertifiedCreateDto certified)
        {
            return new Certified
            {
                Name = certified.Name,
                Expiration = certified.Expiration.FromDateTimeToDateOnly(),
                Description = certified.Description,
                EmployeeId = certified.EmployeeId
            };
        }

        public static void PatchCertified(this Certified certified, CertifiedPatchDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                certified.Name = dto.Name;
            }

            if (dto.Expiration.HasValue && dto.Expiration.Value != DateTime.MinValue)
            {
                certified.Expiration = dto.Expiration.Value.FromDateTimeToDateOnly();
            }

            if (!string.IsNullOrWhiteSpace(dto.Description))
            {
                certified.Description = dto.Description;
            }
        }

        #endregion

        #region "CertifiedCreateDto"

        public static CertifiedCreateDto ToCertifiedCreateDto(this Certified certified)
        {
            return new CertifiedCreateDto
            {
                Name = certified.Name,
                Expiration = certified.Expiration.FromDateOnlyToDateTime(),
                Description = certified.Description,
                EmployeeId = certified.EmployeeId
            };
        }

        #endregion

        #region "CertifiedReadDto"

        public static CertifiedDto ToCertifiedDto(this Certified certified)
        {
            return new CertifiedDto
            {
                Id = certified.Id,
                Code = certified.Code,
                Name = certified.Name,
                Expiration = certified.Expiration.FromDateOnlyToDateTime(),
                Description = certified.Description,
                EmployeeId = certified.EmployeeId
            };
        }

        public static Certified ToCertified(this CertifiedDto certified)
        {
            return new Certified
            {
                Id = certified.Id,
                Code = certified.Code,
                Name = certified.Name,
                Expiration = certified.Expiration.FromDateTimeToDateOnly(),
                Description = certified.Description
            };
        }

        #endregion
    }
}
