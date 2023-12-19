using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;


namespace IbgeBlazor.Infraestructure.Data.Confgurations
{
    internal class StatesConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("ESTADOS");

            builder.HasKey(state => state.Id);

            builder.Property(state => state.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(state => state.Code)
                .IsRequired()
                .HasColumnName("CODIGO_ESTADO")
                .HasMaxLength(2)
                .HasConversion(code => code.CodeNumber, str => str);

            builder.Ignore(state => state.Notifications);
            builder.Ignore(state => state.IsValid);

            builder.Property(state => state.Name)
                .IsRequired()
                .HasColumnName("NOME_ESTADO")
                .HasMaxLength(80);


            builder.HasMany(state => state.Cities)
                .WithOne(city => city.State)
                .HasForeignKey(c => c.StateId)
                .IsRequired();

            builder
            .HasIndex(state => state.Code, "IX_ESTADOS_CODIGO_ESTADO")
            .IsUnique();

        }
    }
}
