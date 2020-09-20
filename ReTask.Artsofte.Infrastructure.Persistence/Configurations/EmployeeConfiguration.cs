using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReTask.Artsofte.Domain.Entities;

namespace ReTask.Artsofte.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees")
                   .HasKey(employee => employee.Id);

            builder.Property(employee => employee.Name)
                   .HasColumnName("name")
                   .HasMaxLength(128);

            builder.Property(employee => employee.Surname)
                   .HasColumnName("surname")
                   .HasMaxLength(128);

            builder.Property(employee => employee.Age)
                   .HasColumnName("age");

            builder.Property(employee => employee.Gender)
                   .HasColumnName("gender");

            builder.HasOne(employee => employee.Department)
                   .WithMany(department => department.Employees)
                   .HasForeignKey(employee => employee.DepartmentId);

            builder.HasOne(employee => employee.Language)
                   .WithMany(lang => lang.Employees)
                   .HasForeignKey(employee => employee.LanguageId);
        }
    }
}
