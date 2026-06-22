using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07D6FD1E0B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorFrame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Side = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Hinges = table.Column<int>(type: "int", nullable: true),
                    Wall_frame_thickness = table.Column<int>(type: "int", nullable: true),
                    Perforation_type_for_shoeing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Perforation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Opening = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Framesheightwithshutter = table.Column<int>(name: "Frames height with shutter", type: "int", nullable: true),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Color = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Textfileforthemachine = table.Column<string>(name: "Text file for the machine", type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    StatusArchive = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DoorFram__3214EC07E5F5871A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Side = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Hinges = table.Column<int>(type: "int", nullable: true),
                    Perforation_type_for_shoeing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Skylight = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Perforation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    ShoeingA = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    ShoeingB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    ShoeingC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Finishing = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Opening = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Leaf = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Internallayoutwidth = table.Column<int>(name: "Internal layout width", type: "int", nullable: true),
                    Internallayoutlength = table.Column<int>(name: "Internal layout length", type: "int", nullable: true),
                    Externallayoutwidth = table.Column<int>(name: "External layout width", type: "int", nullable: true),
                    Externallayoutlength = table.Column<int>(name: "External layout length", type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Textfileforthemachine = table.Column<string>(name: "Text file for the machine", type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    StatusArchive = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Doors__3214EC075E959973", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Phone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC07D25989EF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustId = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Plot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Building_num = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(name: "Floor ", type: "int", nullable: true),
                    Apartment_num = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07D70966A6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Contact_person_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Contact_person_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    CN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC0782E2575A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_ToTable",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    OrderItem_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC07D51337C0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderItem__Order__756D6ECB",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmployeeId",
                table: "Customers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "UQ__DoorFram__3214EC0638DC4EED",
                table: "DoorFrame",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DoorFrame");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
