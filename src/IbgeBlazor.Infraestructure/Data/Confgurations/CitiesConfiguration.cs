using IbgeBlazor.Core.LocalityContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;


namespace IbgeBlazor.Infraestructure.Data.Confgurations
{
    internal class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CIDADE");

            builder.HasKey(city => new
            {
                city.IbgeCode,
                city.UfCode,
                city.CityName

            });

            builder.Property(city => city.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(city => city.UfCode)
                .IsRequired()
                .HasColumnName("CODIGO_ESTADO")
                .HasColumnType(nameof(SqlDbType.Char))
                .HasMaxLength(2);
            //.HasConversion(code => code.CodeNumber, str => str);
            builder.Ignore(city => city.Notifications);

            builder.Property(city => city.UfCode)
                .IsRequired()
                .HasColumnName("CODIGO_IBGE")
                .HasColumnType(nameof(SqlDbType.Char))
                .HasMaxLength(8);

            builder.Ignore(city => city.Notifications);

            builder.Property(city => city.CityName)
                .IsRequired()
                .HasColumnName("NOME_CIDADE")
                .HasColumnType(nameof(SqlDbType.VarChar))
                .HasMaxLength(80);

           // builder.HasIndex(city => city.Code, "IX_ESTATDOS_CODIGO_ESTADO");


        }
    }
}
