using IbgeBlazor.Core.LocalityContext.Entities;
using IbgeBlazor.Core.LocalityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeBlazor.Infraestructure.Data.Configurations
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
                .HasColumnType("char")
                .HasMaxLength(7)
                .HasConversion(code => code.Code, str => new IbgeCode(str));

            builder.Property(city => city.Name)
                .IsRequired()
                .HasColumnName("NOME_MUNICIPIO")
                .HasMaxLength(80);

            builder.Property(city => city.StateId)
                .IsRequired()
                .HasColumnName("UF_ID");

            builder.HasIndex(state => state.Name, "IX_MUNICIPIOS_NOME_MUNICIPIO");

            builder.Ignore(city => city.Notifications);
            builder.Ignore(city => city.IsValid);
        }
    }
}
