using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories (Name,DisplayOrder) Values ('Novel',1)");
            migrationBuilder.Sql("Insert into Categories (Name,DisplayOrder) Values ('Scientific',2)");
            migrationBuilder.Sql("Insert into Categories (Name,DisplayOrder) Values ('Psychology',3)");
            migrationBuilder.Sql("Insert into Categories (Name,DisplayOrder) Values ('Horro',4)");

            migrationBuilder.Sql("Insert into Books (Name,CategoryId,Price,PublishDate) Values ('Big Foot',4,22.12,GetDate())");
            migrationBuilder.Sql("Insert into Books (Name,CategoryId,Price,PublishDate) Values ('Jhonson',1,10.00,GetDate())");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
            migrationBuilder.Sql("Delete from Books");
        }
    }
}
