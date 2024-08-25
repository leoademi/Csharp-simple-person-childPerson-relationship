using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Migrations
{
    internal class FirstMigration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creating Persons table
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "ChildPersons",
                columns: table => new
                {
                    ChildPersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ParentPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildPersons", x => x.ChildPersonId);
                    table.ForeignKey(
                        name: "FK_ChildPersons_Persons_ParentPersonId",
                        column: x => x.ParentPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildPersons_ParentPersonId",
                table: "ChildPersons",
                column: "ParentPersonId");

            migrationBuilder.CreateTable(
               name: "HealthInsuranceDocuments",
               columns: table => new
               {
                   HealthInsuranceDocumentId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   DateOfAccident = table.Column<DateTime>(nullable: false),
                   DocumentIdentificationNumber = table.Column<string>(nullable: true),
                   DoctorName = table.Column<string>(nullable: true),
                   BodilyInjuries = table.Column<string>(nullable: true),
                   ParentPersonId = table.Column<int>(nullable: true),
                   ChildPersonId = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_HealthInsuranceDocuments", x => x.HealthInsuranceDocumentId);
                   table.ForeignKey(
                       name: "FK_HealthInsuranceDocuments_Persons_ParentPersonId",
                       column: x => x.ParentPersonId,
                       principalTable: "Persons",
                       principalColumn: "PersonId",
                       onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                       name: "FK_HealthInsuranceDocuments_ChildPersons_ChildPersonId",
                       column: x => x.ChildPersonId,
                       principalTable: "ChildPersons",
                       principalColumn: "ChildPersonId",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateIndex(
                name: "IX_HealthInsuranceDocuments_ParentPersonId",
                table: "HealthInsuranceDocuments",
                column: "ParentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInsuranceDocuments_ChildPersonId",
                table: "HealthInsuranceDocuments",
                column: "ChildPersonId");
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildPersons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
               name: "HealthInsuranceDocuments");
        }
    }
}
