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

            builder.HasKey(state => new
            {
                state.Id,
                state.Code
            });

            builder.Property(state => state.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(state => state.Code)
                .IsRequired()
                .HasColumnName("CODIGO_ESTADO")
                .HasColumnType(nameof(SqlDbType.Char))
                .HasMaxLength(2)
                .HasConversion(code => code.CodeNumber, str => str);

            builder.Ignore(state => state.Notifications);
                
            builder.Property(state => state.Description)
                .IsRequired()
                .HasColumnName("NOME_ESTADO")
                .HasColumnType(nameof(SqlDbType.VarChar))
                .HasMaxLength(80);

            builder.HasIndex(state => state.Code, "IX_ESTATDOS_CODIGO_ESTADO");
                
        }
    }
}
