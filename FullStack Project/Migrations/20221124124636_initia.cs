using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankManagementSystem.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonorDetails",
                columns: table => new
                {
                    donorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donorMob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donorAge = table.Column<int>(type: "int", nullable: false),
                    donorWeight = table.Column<int>(type: "int", nullable: false),
                    donorheight = table.Column<int>(type: "int", nullable: false),
                    donorBloodType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorDetails", x => x.donorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorDetails");
        }
    }
}
