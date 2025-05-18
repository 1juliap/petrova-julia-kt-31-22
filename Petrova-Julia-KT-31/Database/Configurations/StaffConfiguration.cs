using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Petrova_Julia_KT_31.Models;
using Petrova_Julia_KT_31.Database.Helpers;

namespace Petrova_Julia_KT_31.Database.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        private const string TableName = "cd_staff";

        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder
                .HasKey(p => p.StaffId)
                .HasName($"pk_{TableName}_staff_id");

            builder.Property(p => p.StaffId)
                .ValueGeneratedOnAdd()
                .HasColumnName("staff_id")
                .HasComment("Идентификатор должности");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("c_staff_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название должности");

            builder.ToTable(TableName);
        }
    }

}
