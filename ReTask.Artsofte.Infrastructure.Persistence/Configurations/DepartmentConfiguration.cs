using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReTask.Artsofte.Domain.Entities;

namespace ReTask.Artsofte.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("department")
                   .HasKey(department => department.Id);

            builder.Property(department => department.Id)
                   .HasColumnName("id");

            builder.Property(department => department.Name)
                   .HasColumnName("name");

            builder.Property(department => department.Floor)
                   .HasColumnName("floor");
        }
    }
}
