using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoEf.Migrations
{
    public partial class DbInitialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Learn the basics of C#" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 2, 1, ".NET" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 3, 1, ".NET CLI" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[] { 1, 1, "C#" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_GroupId",
                table: "Items",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
