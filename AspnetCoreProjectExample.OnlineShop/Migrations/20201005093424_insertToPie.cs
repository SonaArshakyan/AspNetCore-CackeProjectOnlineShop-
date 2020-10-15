using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCoreProjectExample.OnlineShop.Migrations
{
    public partial class insertToPie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "PieId", "AllergyInformation", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsPieOfWeek", "LongDescription", "Name", "Prices", "ShortDescription" },
                values: new object[,]
                {                  
                    { 2, null, 1, null, "~/ images / cacke.jpg", true, false, "Lorem jan", "Apple Pie", 12, "Our Famous apple pies" },
                    { 3, null, 2, null, "~/ images / cacke.jpg", true, false, "Lorem jan", "Apple Pie", 12, "Our Famous apple pies" },
                    { 4, null, 3, null, "~/ images / cacke.jpg", true, true, "Lorem jan", "Apple Pie", 12, "Our Famous apple pies" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 3);
         
        }
    }
}
