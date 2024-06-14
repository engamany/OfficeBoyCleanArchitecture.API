using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeBoy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days_of_weeks",
                columns: table => new
                {
                    day_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day_of_week", x => x.day_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dept_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dept_id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PictureURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    TimeNeeded = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Drinks__C094D3C82DFE6600", x => x.DrinkID);
                });

            migrationBuilder.CreateTable(
                name: "OfficeLocations",
                columns: table => new
                {
                    OfficeLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    Floor_number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OfficeLo__0B87E92C5B3A179F", x => x.OfficeLocationID);
                    table.ForeignKey(
                        name: "FK_OfficeLocations_Departments",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Dept_id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    OfficeLocationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1688E7AB7", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employees__Offic__3587F3E0",
                        column: x => x.OfficeLocationID,
                        principalTable: "OfficeLocations",
                        principalColumn: "OfficeLocationID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeBoyShifts",
                columns: table => new
                {
                    ShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    Day_Shift = table.Column<int>(type: "int", nullable: true),
                    Start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OfficeBo__C0A838E19181F165", x => x.ShiftID);
                    table.ForeignKey(
                        name: "FK_OfficeBoyShifts_Employees",
                        column: x => x.emp_id,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_id = table.Column<int>(type: "int", nullable: false),
                    DrinkID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OfficeLocationID = table.Column<int>(type: "int", nullable: false),
                    IndividualOrder = table.Column<bool>(type: "bit", nullable: false),
                    OrderStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    orderdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Is_Company = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orderes__C3905BAF43F7B5F3", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orderes_Drinks",
                        column: x => x.DrinkID,
                        principalTable: "Drinks",
                        principalColumn: "DrinkID");
                    table.ForeignKey(
                        name: "FK_Orderes_Employees",
                        column: x => x.emp_id,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Orderes_OfficeLocations",
                        column: x => x.OfficeLocationID,
                        principalTable: "OfficeLocations",
                        principalColumn: "OfficeLocationID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Orders",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeLocationID",
                table: "Employees",
                column: "OfficeLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeBoyShifts_emp_id",
                table: "OfficeBoyShifts",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocations_dept_id",
                table: "OfficeLocations",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DrinkID",
                table: "Orders",
                column: "DrinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_emp_id",
                table: "Orders",
                column: "emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfficeLocationID",
                table: "Orders",
                column: "OfficeLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days_of_weeks");

            migrationBuilder.DropTable(
                name: "OfficeBoyShifts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OfficeLocations");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
