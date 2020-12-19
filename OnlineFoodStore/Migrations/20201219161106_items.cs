using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineFoodStore.Migrations
{
    public partial class items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItemContext_Foods_FoodId",
                table: "ShoppingCartItemContext");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItemContext",
                table: "ShoppingCartItemContext");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItemContext",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItemContext_FoodId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Foods_FoodId",
                table: "ShoppingCartItems",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Foods_FoodId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoppingCartItemContext");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItemContext",
                newName: "IX_ShoppingCartItemContext_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItemContext",
                table: "ShoppingCartItemContext",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItemContext_Foods_FoodId",
                table: "ShoppingCartItemContext",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
