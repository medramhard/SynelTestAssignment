CREATE PROCEDURE [dbo].[spEmployee_Add]
	@PayrollNumber nvarchar(50),
    @Forename nvarchar(50),
    @Surname nvarchar(50),
    @BirthDate datetime2(7),
    @Phone nvarchar(20),
    @CellPhone nvarchar(20),
    @StreetAddress nvarchar(50),
    @City nvarchar(50),
    @Postcode nvarchar(20),
    @Email nvarchar(50),
    @StartDate datetime2(7)
AS

begin
    insert into [dbo].[Employee] ([PayrollNumber], [Forename], [Surname], [BirthDate], [Phone], [CellPhone], [StreetAddress], [City], [Postcode], [Email], [StartDate])
    values (@PayrollNumber, @Forename, @Surname, @BirthDate, @Phone, @CellPhone, @StreetAddress, @City, @Postcode, @Email, @StartDate);
end
