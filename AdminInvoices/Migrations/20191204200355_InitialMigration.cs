using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminInvoices.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AdminInvoices");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "AdminInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "AdminInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Invoiced = table.Column<bool>(nullable: false),
                    Dispatched = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "AdminInvoices",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "AdminInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    OrderId1 = table.Column<int>(nullable: true),
                    Sent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalSchema: "AdminInvoices",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "AdminInvoices",
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "Surname" },
                values: new object[,]
                {
                    { 1, "bob@example.com", "Robert", "Robertson" },
                    { 2, "betty@example.com", "Betty", "Thornton" },
                    { 3, "jin@example.com", "Jin", "Marsdon" }
                });

            migrationBuilder.InsertData(
                schema: "AdminInvoices",
                table: "Invoices",
                columns: new[] { "Id", "CustomerId", "OrderId", "OrderId1", "Sent" },
                values: new object[,]
                {
                    { -1, -1, -1, null, false },
                    { 1, 2, 2, null, false },
                    { 2, 2, 2, null, true },
                    { 3, 3, 3, null, true }
                });

            migrationBuilder.InsertData(
                schema: "AdminInvoices",
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Dispatched", "InvoiceId", "Invoiced" },
                values: new object[,]
                {
                    { 4, 1, false, 4, true },
                    { 1, 2, false, -1, false },
                    { 2, 2, false, 2, true },
                    { 3, 3, true, 3, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId1",
                schema: "AdminInvoices",
                table: "Invoices",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "AdminInvoices",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "AdminInvoices");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "AdminInvoices");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "AdminInvoices");
        }
    }
}
