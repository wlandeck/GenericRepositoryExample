using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.ConfigurationMappings
{
    class MyTaskConfiguration : EntityTypeConfiguration<MyTask>
    {
        public MyTaskConfiguration()
        {
            ToTable("Tasks");
            // Primary Key
            this.HasKey(t => t.IdKey);

            // Properties
            this.Property(t => t.Task)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.Property(t => t.IdKey).HasColumnName("Id");
            this.Property(t => t.IdKey).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Task).HasColumnName("Task");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
