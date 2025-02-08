using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class getAllPersonsSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
            Create Procedure [dbo].[GetAllPersons]
            As Begin
            Select * from dbo.Persons;
            End
            ";
            migrationBuilder.Sql(sp_GetAllPersons);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
                Drop procedure dbo.GetAllPersons;
            ";
            migrationBuilder.Sql(sp_GetAllPersons);
        }
    }
}
