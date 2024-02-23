using Leo.ControleCertificacoes.Core.Constants;
using Leo.ControleCertificacoes.Core.Domain.Entities;
using Leo.ControleCertificacoes.Core.Infra.Context.Configuration.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leo.ControleCertificacoes.Core.Infra.Context.Configuration
{
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder
                .Property(employee => employee.Name)
                .HasColumnType(SQLiteDataTypes.TEXT)
                .IsRequired();

            builder
                .Property(employee => employee.Department)
                .HasColumnType(SQLiteDataTypes.TEXT);

            builder
                .Property(employee => employee.NumberOfCertifieds)
                .HasColumnType(SQLiteDataTypes.INTEGER)
                .IsRequired();

            builder
                .Navigation(employee => employee.Certifieds)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
