using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HayvanBarinagiCalisma.Data.Migrations
{
    public partial class AdminlerinEklenmesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "18df1b10-dea0-4520-b5a4-36849d400d7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "565d8f51-8df6-4cba-b5fa-b9ff59c271c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "4e7897a1-f6ef-4d95-b3ca-83d71551b899", true, "AQAAAAEAACcQAAAAEKV5VfjPEmmwNhehmbDAWkWXkbGpx/O2UEH4FvgLcVtUhbpHMvfYhQIOTEz9OSuKzA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "Adres", "ConcurrencyStamp", "DogumTarihi", "Email", "EmailConfirmed", "HayvanId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rol", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e576", 0, null, null, "1c85e7d9-e23d-47ef-acac-8b2d52d87c96", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b181200378@sakarya.edu.tr", true, 0, false, null, "B181200378@SAKARYA.EDU.TR", "B181200378@SAKARYA.EDU.TR", "AQAAAAEAACcQAAAAENQfn5Tth3Chqk32k6cqBF6lNlNpWxPx7mJIjqzbhpBI/mFteH8iIM1991t4aGIaTQ==", null, false, null, "", null, false, "b181200378@sakarya.edu.tr" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e577", 0, null, null, "0a45e9f3-cbca-4d4d-adc3-bebc13d042c9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "g171210105@sakarya.edu.tr", true, 0, false, null, "G171210105@SAKARYA.EDU.TR", "G171210105@SAKARYA.EDU.TR", "AQAAAAEAACcQAAAAEPhYjBlWeH0vYwy+j0CELb2GGQ59uD97dqiUDXHCi7NuJya+3hGMK6W6mHMgdd6YdQ==", null, false, null, "", null, false, "g171210105@sakarya.edu.tr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e576", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e577", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e576", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e577", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "55e020cd-e373-4117-b78f-7e6c6c5580ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ed94acc0-fa9e-4977-8f2c-75be26739ebb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "f2718039-453b-44b4-beea-f59fa7050934", false, "AQAAAAEAACcQAAAAEEE/JRniikX6w6Gcmg3KQF7/1HbyZfBJqW8i+UTThF7gMS4eftU0RmUB8QtIBsr8wA==" });
        }
    }
}
