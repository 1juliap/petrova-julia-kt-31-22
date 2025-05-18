using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Petrova_Julia_KT_31.Models;
using Petrova_Julia_KT_31.Database.Helpers;

namespace Petrova_Julia_KT_31.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        private const string TableName = "cd_workload";

        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder
                .HasKey(t => t.WorkloadId)
                .HasName($"pk_{TableName}_workload_id");

            builder.Property(t => t.WorkloadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("workload_id")
                .HasComment("Идентификатор нагрузки на преподавателя");

            builder.Property(t => t.Hours)
                .IsRequired()
                .HasColumnName("c_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество часов");

            builder.ToTable(TableName);
        }
    }

}
