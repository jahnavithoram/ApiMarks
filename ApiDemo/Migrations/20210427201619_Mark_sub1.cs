using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDemo.Migrations
{
    public partial class Mark_sub1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarksModel",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    SubName = table.Column<string>(nullable: true),
                    marks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarksModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    subName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarksModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");
        }
    }
}
