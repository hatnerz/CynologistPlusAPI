using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdCLientDogOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Orders__ClientId__49C3F6B7",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Orders",
                newName: "Approved");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ClientId",
                table: "Dogs",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Clients_ClientId",
                table: "Dogs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Clients_ClientId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Orders",
                newName: "IsApproved");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
