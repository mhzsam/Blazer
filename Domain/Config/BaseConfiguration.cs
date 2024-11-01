using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.Entites.Base
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {     

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.InsertBy).IsRequired();
            builder.Property(p => p.InsertDate).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
