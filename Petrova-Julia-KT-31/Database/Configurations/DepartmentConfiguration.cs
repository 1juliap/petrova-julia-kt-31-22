using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Petrova_Julia_KT_31.Models;
using Petrova_Julia_KT_31.Database.Helpers;

namespace Petrova_Julia_KT_31.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
               .HasKey(d => d.DepartmentId)
               .HasName($"pk_{TableName}_department_id");

            builder.Property(d => d.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("department_id")
                .HasComment("Идентификатор кафедры");

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.ToTable(TableName);
        }
    }

}
