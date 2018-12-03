using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleToDo.Models.Domain;

namespace SimpleToDo.Database.Configurations
{
    internal class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired().IsUnicode();
            builder.Property(x => x.Description).IsRequired(false).IsUnicode();
            builder.Property(x => x.Status);
            builder.Property(x => x.Priority);
            builder.Property(x => x.DueDate).HasColumnType("DATETIME2").IsRequired();
        }
    }
}