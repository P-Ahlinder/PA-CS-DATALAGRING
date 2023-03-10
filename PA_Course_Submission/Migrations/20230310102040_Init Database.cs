using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int(10,1)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Status_Ongoing = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Status_Unsolved = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Status_Solved = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobilePhone = table.Column<string>(type: "char(13)", nullable: true),
                    CaseId = table.Column<int>(type: "int(10,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CaseId",
                table: "Customers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
