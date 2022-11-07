using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class StoreProcedureCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProc = @"CREATE Procedure proc_get_subcategories @categoryId varchar(10)";
            createProc += " AS ";
            createProc += " SELECT * FROM SubCategories WHERE (@categoryId = '' OR CategoryId = @categoryId)";
            migrationBuilder.Sql(createProc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProc = @"DROP Procedure proc_get_subcategories";
            migrationBuilder.Sql(dropProc);
        }
    }
}
