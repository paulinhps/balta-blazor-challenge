using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace IbgeBlazor.Infraestructure.Data.Confgurations
{
    internal class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("MUNICIPIOS");

            builder.HasKey(city => city.Id);

            builder.Property(city => city.Id)
                .IsRequired()
                .HasColumnName("CODIGO_MUNICIPIO")
                .HasColumnType(nameof(SqlDbType.Char))
                .HasMaxLength(7)
                .HasConversion(code => code.Code, str => new IbgeCode(str));

            builder.Property(city => city.CityName)
                .IsRequired()
                .HasColumnName("NOME_MUNICIPIO")
                .HasColumnType(nameof(SqlDbType.VarChar))
                .HasMaxLength(80);

            builder.Property(city => city.StateId)
                .IsRequired()
                .HasColumnName("CODIGO_UF")
                .HasColumnType(nameof(SqlDbType.Int));

            // 1 Municipio (City) está em 1 Estado (State)
            // 1 Estado (State) possui Muitos (N) Municípios (City)

            // builder.HasOne(city => city.State)
            //     .WithMany(state => state.Cities)
            //     .HasForeignKey(e => e.StateId)
            //     .IsRequired();

            builder.HasIndex(state => state.CityName, "IX_MUNICIPIOS_NOME_MUNICIPIO");

            builder.Ignore(city => city.Notifications);
            builder.Ignore(city => city.IsValid);
        }
    }
}
