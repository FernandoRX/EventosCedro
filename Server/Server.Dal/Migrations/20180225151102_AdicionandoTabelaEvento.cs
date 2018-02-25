using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Server.Dal.Migrations
{
    public partial class AdicionandoTabelaEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    FaixaEtaria = table.Column<string>(nullable: true),
                    HoraFim = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<int>(nullable: false),
                    IngressosVendidos = table.Column<int>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    MaximoIngressos = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    OpenBar = table.Column<bool>(nullable: false),
                    QuantidadeDeAmbientes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
