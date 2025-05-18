using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Petrova_Julia_KT_31.Models;
using Petrova_Julia_KT_31.Database.Helpers;

namespace Petrova_Julia_KT_31.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(ad => ad.AcademicDegreeId)
                .HasName($"pk_{TableName}_academic_degree_id");

            builder.Property(ad => ad.AcademicDegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор академической степени");

            builder.Property(ad => ad.Name)
                .IsRequired()
                .HasColumnName("c_academic_degree_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.ToTable(TableName);
        }
    }
}


