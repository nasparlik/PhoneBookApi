using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PhoneBookApi.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Titles (Text) VALUES ('Mr.')");
            migrationBuilder.Sql("INSERT INTO Titles (Text) VALUES ('Ms.')");
            migrationBuilder.Sql("INSERT INTO Titles (Text) VALUES ('Dr.')");
            migrationBuilder.Sql("INSERT INTO Records (Address,Email,PhoneNumber,FullName,LastUpdate,TitleId) VALUES ('London','nsopca@gmail.com', '07435478432', 'Cosmin Sopca', GETDATE(),1)");
            migrationBuilder.Sql("INSERT INTO Records (Address,Email,PhoneNumber,FullName,LastUpdate,TitleId) VALUES ('London','abcds@gmail.com', '07832342432', 'DCBA ABCD', GETDATE(),1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Records");
        }
    }
}
