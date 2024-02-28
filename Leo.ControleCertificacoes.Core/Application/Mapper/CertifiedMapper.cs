using Leo.ControleCertificacoes.Core.Application.Dtos.Certified;
using Leo.ControleCertificacoes.Core.Domain.Entities;

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
                Expiration = DateTimeToDateOnly(certified.Expiration),
                Description = certified.Description,
                EmployeeId = certified.EmployeeId
            };
        }

        #endregion

        #region "CertifiedCreateDto"

        public static CertifiedCreateDto ToCertifiedCreateDto(this Certified certified)
        {
            return new CertifiedCreateDto
            {
                Name = certified.Name,
                Expiration = DateOnlyToDateTime(certified.Expiration),
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
                Expiration = certified.Expiration,
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
                Expiration = certified.Expiration,
                Description = certified.Description
            };
        }

        #endregion

        #region "Private Methods"

        private static DateOnly DateTimeToDateOnly(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        private static DateTime DateOnlyToDateTime(DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }

        #endregion
    }
}
