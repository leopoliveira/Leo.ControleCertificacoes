using Leo.ControleCertificacoes.Core.Constants;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.Context.Configuration.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leo.ControleCertificacoes.Core.Infra.Contecertifiedt.Configuration
{
    public class CertifiedConfiguration : BaseConfiguration<Certified>
    {
        public override void Configure(EntityTypeBuilder<Certified> builder)
        {
            base.Configure(builder);

            builder
                .Property(certified => certified.Name)
                .HasColumnType(SQLiteDataTypes.TEXT)
                .IsRequired();

            builder
                .Property(certified => certified.Expiration)
                .HasColumnType(SQLiteDataTypes.TEXT)
                .IsRequired();

            builder
                .Property(certified => certified.Description)
                .HasColumnType(SQLiteDataTypes.TEXT);

            builder
                .HasOne(certified => certified.Employee)
                .WithMany(employee => employee.Certifieds)
                .HasForeignKey(certified => certified.EmployeeId)
                .IsRequired();
        }
    }
}
