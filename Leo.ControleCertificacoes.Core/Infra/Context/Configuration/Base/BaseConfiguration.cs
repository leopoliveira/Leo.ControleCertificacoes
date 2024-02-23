using Leo.ControleCertificacoes.Core.Constants;
using Leo.ControleCertificacoes.Core.Domain.Entities.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leo.ControleCertificacoes.Core.Infra.Context.Configuration.Base
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityWithIdAndCode
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType(SQLiteDataTypes.TEXT);

            builder
                .Property(x => x.Code)
                .HasColumnType(SQLiteDataTypes.INTEGER);

            builder
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}
