using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeSchedule.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeSetup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeSetup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "availability",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empID = table.Column<int>(type: "int", nullable: false),
                    epmstpid = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    st = table.Column<DateTime>(type: "datetime2", nullable: false),
                    et = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availability", x => x.id);
                    table.ForeignKey(
                        name: "FK_availability_employeeSetup_epmstpid",
                        column: x => x.epmstpid,
                        principalTable: "employeeSetup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_availability_epmstpid",
                table: "availability",
                column: "epmstpid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "availability");

            migrationBuilder.DropTable(
                name: "employeeSetup");
        }
    }
}
