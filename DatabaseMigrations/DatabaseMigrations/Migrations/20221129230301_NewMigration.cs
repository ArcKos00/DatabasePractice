using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseMigrations.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactLName",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CurrentOrder",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DiscountAvailable",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PaymentMethods",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SizeURL",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TypeGoods",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "URl",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "AvailableSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountAvailable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdSKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MSRP",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityPerUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReorderLevel",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitWeight",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitsInStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitsOnOrders",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VeridorProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "availableColors",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ErrLoc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Freight",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullFilling",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReeMag",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RequiredDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SalesTax",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipData",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Transact",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Fulfilled",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IdSKU",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ShipDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BuildingAddress1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BuildingCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BuildingCountry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BuildingPostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Buildingregion",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CardExpMo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CardExpYr",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditCardTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipAddress1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipCountry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipPostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipRegion",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "VoiseMail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Discription",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ContactLName",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "CurrentOrder",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DiscountAvailable",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DiscountType",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethods",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeURL",
                table: "Suppliers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "TypeGoods",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "URl",
                table: "Suppliers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "AvailableSize",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<bool>(
                name: "DiscountAvailable",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdSKU",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MSRP",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Products",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "QuantityPerUnit",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReorderLevel",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<float>(
                name: "UnitWeight",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UnitsInStock",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitsOnOrders",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VeridorProduct",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "availableColors",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ErrLoc",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Freight",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<bool>(
                name: "FullFilling",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReeMag",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequiredDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SalesTax",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipData",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Transact",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                table: "OrderDetails",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "OrderDetails",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<bool>(
                name: "Fulfilled",
                table: "OrderDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdSKU",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "OrderDetails",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipDate",
                table: "OrderDetails",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "BuildingAddress1",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "BuildingCity",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "BuildingCountry",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "BuildingPostalCode",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Buildingregion",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "CardExpMo",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "CardExpYr",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardTypeId",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ShipAddress1",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ShipCity",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ShipCountry",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "ShipPostalCode",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShipRegion",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "VoiseMail",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AlterColumn<string>(
                name: "Discription",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: " ",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Category",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
