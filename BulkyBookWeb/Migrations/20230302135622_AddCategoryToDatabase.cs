using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)// nullable is false because it is ID
                        .Annotation("SqlServer:Identity", "1, 1"),// id is increamenting by 1 every time 
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),// nullable is false becuase we specify it as "Required"
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),// nullable is false because it is an integer property
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
