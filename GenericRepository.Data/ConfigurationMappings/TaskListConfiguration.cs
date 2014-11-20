using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.ConfigurationMappings
{
    public class TaskListConfiguration : EntityTypeConfiguration<TaskList>
    {
        public TaskListConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TaskLists");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.Tasks)
                .WithMany(t => t.TaskLists)
                .Map(m =>
                {
                    m.ToTable("TasksToTaskList");
                    m.MapLeftKey("TaskListId");
                    m.MapRightKey("TaskId");
                });


        }
    }
}
