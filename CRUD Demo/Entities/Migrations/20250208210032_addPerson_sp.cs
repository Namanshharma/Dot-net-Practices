using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class addPerson_sp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"
                Create procedure dbo.AddPerson (@PersonId uniqueidentifier, @PersonName nvarchar(40), 
                    @Email nvarchar(40), @DateOfBirth datetime2(7), @Gender nvarchar(7), @CountryId uniqueidentifier,
                    @Address nvarchar(200), @ReveiveNewsLetters bit
                )
                as begin
                Insert into dbo.Persons (PersonId, PersonName, Email, DateOfBirth, Gender, CountryId, Address, 
                ReveiveNewsLetters)
                values (@PersonId, @PersonName, @Email, @DateofBirth, @Gender, @CountryId, @Address, 
                @ReveiveNewsLetters);
                End
            ";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp = @"drop procedure dbo.AddPerson";
            migrationBuilder.Sql(sp);
        }
    }
}
