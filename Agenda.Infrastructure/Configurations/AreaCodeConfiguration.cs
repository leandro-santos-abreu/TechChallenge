using Agenda.Domain.Entities;
using Agenda.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Configurations
{
    public class AreaCodeConfiguration : IEntityTypeConfiguration<AreaCode>
    {
        public void Configure(EntityTypeBuilder<AreaCode> builder)
        {
            builder.ToTable("AreaCodes");
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code).HasColumnType("VARCHAR").HasMaxLength(2).IsRequired();
            builder.Property(x => x.FederalUnity).HasColumnType("VARCHAR").HasMaxLength(13).IsRequired();
            builder.Property(x => x.FederalUnity).HasColumnType("VARCHAR").HasMaxLength(19).IsRequired();

            #region Midwest
            builder.HasData(
                new AreaCode()
                {
                    Code = "61",
                    FederalUnity = "Distrito Federal",
                    Capital = "Brasília",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "62",
                    FederalUnity = "Goiás",
                    Capital = "Goiânia",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "64",
                    FederalUnity = "Goiás",
                    Capital = "Goiânia",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "65",
                    FederalUnity = "Mato Grosso",
                    Capital = "Cuiabá",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "66",
                    FederalUnity = "Mato Grosso",
                    Capital = "Cuiabá",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "67",
                    FederalUnity = "Mato Grosso do Sul",
                    Capital = "Campo Grande",
                });
            #endregion

            #region Northeast
            builder.HasData(
                new AreaCode()
                {
                    Code = "82",
                    FederalUnity = "Alagoas",
                    Capital = "Maceió",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "71",
                    FederalUnity = "Bahia",
                    Capital = "Salvador",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "73",
                    FederalUnity = "Bahia",
                    Capital = "Salvador",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "74",
                    FederalUnity = "Bahia",
                    Capital = "Salvador",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "75",
                    FederalUnity = "Bahia",
                    Capital = "Salvador",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "77",
                    FederalUnity = "Bahia",
                    Capital = "Salvador",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "85",
                    FederalUnity = "Ceará",
                    Capital = "Fortaleza",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "88",
                    FederalUnity = "Ceará",
                    Capital = "Fortaleza",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "98",
                    FederalUnity = "Maranhão",
                    Capital = "São Luís",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "99",
                    FederalUnity = "Maranhão",
                    Capital = "São Luís",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "83",
                    FederalUnity = "Paraíba",
                    Capital = "João Pessoa",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "81",
                    FederalUnity = "Pernambuco",
                    Capital = "Recife",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "87",
                    FederalUnity = "Pernambuco",
                    Capital = "Recife",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "86",
                    FederalUnity = "Piauí",
                    Capital = "Teresina",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "89",
                    FederalUnity = "Piauí",
                    Capital = "Teresina",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "84",
                    FederalUnity = "Rio Grande do Norte",
                    Capital = "Natal",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "79",
                    FederalUnity = "Sergipe",
                    Capital = "Aracaju",
                });
            #endregion

            #region North
            builder.HasData(
                new AreaCode()
                {
                    Code = "68",
                    FederalUnity = "Acre",
                    Capital = "Rio Branco",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "96",
                    FederalUnity = "Amapá",
                    Capital = "Macapá",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "92",
                    FederalUnity = "Amazonas",
                    Capital = "Manaus",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "97",
                    FederalUnity = "Amazonas",
                    Capital = "Manaus",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "91",
                    FederalUnity = "Pará",
                    Capital = "Belém",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "93",
                    FederalUnity = "Pará",
                    Capital = "Belém",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "94",
                    FederalUnity = "Pará",
                    Capital = "Belém",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "69",
                    FederalUnity = "Rondônia",
                    Capital = "Porto Velho",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "95",
                    FederalUnity = "Roraima",
                    Capital = "Boa Vista",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "63",
                    FederalUnity = "Tocantins",
                    Capital = "Palmas",
                });
            #endregion

            #region Southeast
            builder.HasData(
                new AreaCode()
                {
                    Code = "27",
                    FederalUnity = "Espírito Santo",
                    Capital = "Vitória",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "28",
                    FederalUnity = "Espírito Santo",
                    Capital = "Vitória",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "31",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "32",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "33",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "34",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "35",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "37",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "38",
                    FederalUnity = "Minas Gerais",
                    Capital = "Belo Horizonte",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "21",
                    FederalUnity = "Rio de Janeiro",
                    Capital = "Rio de Janeiro",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "22",
                    FederalUnity = "Rio de Janeiro",
                    Capital = "Rio de Janeiro",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "24",
                    FederalUnity = "Rio de Janeiro",
                    Capital = "Rio de Janeiro",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "11",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "12",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "13",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "14",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "15",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "16",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "17",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "18",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "19",
                    FederalUnity = "São Paulo",
                    Capital = "São Paulo",
                });
            #endregion

            #region South
            builder.HasData(
                new AreaCode()
                {
                    Code = "41",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "42",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "43",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "44",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "45",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "46",
                    FederalUnity = "Paraná",
                    Capital = "Curitiba",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "51",
                    FederalUnity = "Rio Grande do Sul",
                    Capital = "Porto Alegre",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "53",
                    FederalUnity = "Rio Grande do Sul",
                    Capital = "Porto Alegre",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "54",
                    FederalUnity = "Rio Grande do Sul",
                    Capital = "Porto Alegre",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "55",
                    FederalUnity = "Rio Grande do Sul",
                    Capital = "Porto Alegre",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "47",
                    FederalUnity = "Santa Catarina",
                    Capital = "Florianópolis",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "48",
                    FederalUnity = "Santa Catarina",
                    Capital = "Florianópolis",
                });

            builder.HasData(
                new AreaCode()
                {
                    Code = "49",
                    FederalUnity = "Santa Catarina",
                    Capital = "Florianópolis",
                });

            #endregion

        }
    }
}
