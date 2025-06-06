using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameProductTagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_product_ProductsId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_tag_TagsId",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.RenameTable(
                name: "ProductTag",
                newName: "product_tag");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagsId",
                table: "product_tag",
                newName: "IX_product_tag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_tag",
                table: "product_tag",
                columns: new[] { "ProductsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_product_tag_product_ProductsId",
                table: "product_tag",
                column: "ProductsId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_tag_tag_TagsId",
                table: "product_tag",
                column: "TagsId",
                principalTable: "tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tag_product_ProductsId",
                table: "product_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_product_tag_tag_TagsId",
                table: "product_tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_tag",
                table: "product_tag");

            migrationBuilder.RenameTable(
                name: "product_tag",
                newName: "ProductTag");

            migrationBuilder.RenameIndex(
                name: "IX_product_tag_TagsId",
                table: "ProductTag",
                newName: "IX_ProductTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                columns: new[] { "ProductsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_product_ProductsId",
                table: "ProductTag",
                column: "ProductsId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_tag_TagsId",
                table: "ProductTag",
                column: "TagsId",
                principalTable: "tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
