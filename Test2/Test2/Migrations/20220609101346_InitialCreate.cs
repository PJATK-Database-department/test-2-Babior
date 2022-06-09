using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Confectioneries",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectioneries", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.IdClientOrder);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Employees_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfectioneryClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false),
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientOrderIdClientOrder = table.Column<int>(type: "int", nullable: true),
                    ConfectioneryIdConfectionery = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfectioneryClientOrders", x => new { x.IdClientOrder, x.IdConfectionery });
                    table.ForeignKey(
                        name: "FK_ConfectioneryClientOrders_ClientOrders_ClientOrderIdClientOrder",
                        column: x => x.ClientOrderIdClientOrder,
                        principalTable: "ClientOrders",
                        principalColumn: "IdClientOrder");
                    table.ForeignKey(
                        name: "FK_ConfectioneryClientOrders_Confectioneries_ConfectioneryIdConfectionery",
                        column: x => x.ConfectioneryIdConfectionery,
                        principalTable: "Confectioneries",
                        principalColumn: "IdConfectionery");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Karyna", "Bartashevich" },
                    { 2, "Nastya", "Babior" },
                    { 3, "Hanna", "Tamkovich" }
                });

            migrationBuilder.InsertData(
                table: "Confectioneries",
                columns: new[] { "IdConfectionery", "Name", "PricePerOne" },
                values: new object[,]
                {
                    { 1, "Twix", 4m },
                    { 2, "Snickers", 5m },
                    { 3, "Mars", 4m }
                });

            migrationBuilder.InsertData(
                table: "ConfectioneryClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "ClientOrderIdClientOrder", "Comments", "ConfectioneryIdConfectionery" },
                values: new object[] { 2, 2, 3, null, "None", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "IdEmployee", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "William", "Shakespeare" },
                    { 2, "Lizaveta", "Babior" },
                    { 3, "Iman", "Sayyadzadeh" }
                });

            migrationBuilder.InsertData(
                table: "ClientOrders",
                columns: new[] { "IdClientOrder", "ClientIdClient", "Comments", "CompletionDate", "EmployeeIdEmployee", "OrderDate" },
                values: new object[] { 1, 1, "No problems occured", new DateTime(2022, 6, 9, 12, 13, 46, 341, DateTimeKind.Local).AddTicks(7480), 1, new DateTime(2022, 6, 8, 12, 13, 46, 341, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_ClientIdClient",
                table: "ClientOrders",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_EmployeeIdEmployee",
                table: "ClientOrders",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryClientOrders_ClientOrderIdClientOrder",
                table: "ConfectioneryClientOrders",
                column: "ClientOrderIdClientOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryClientOrders_ConfectioneryIdConfectionery",
                table: "ConfectioneryClientOrders",
                column: "ConfectioneryIdConfectionery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfectioneryClientOrders");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "Confectioneries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
