USE [master]
GO

IF EXISTS(
    select *
    from sys.databases
    where name = 'DominionCardTracker')
BEGIN
	ALTER DATABASE DominionCardTracker SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE DominionCardTracker;
END

CREATE DATABASE DominionCardTracker;
ALTER DATABASE DominionCardTracker SET RECOVERY SIMPLE;
GO

USE DominionCardTracker
GO

CREATE TABLE Card(
	CardID int IDENTITY(1,1) NOT NULL,
	CardSetID int NOT NULL,
	CardCost int NOT NULL,
	CardTitle varchar(20) NOT NULL,
	ImagePath varchar(50) NOT NULL,
CONSTRAINT PK_Card PRIMARY KEY CLUSTERED (CardID ASC)
)
GO


CREATE TABLE CardCategory(
	CardID int NOT NULL,
	CategoryID int NOT NULL,
CONSTRAINT PK_CardCategory PRIMARY KEY CLUSTERED (CardID ASC, CategoryID ASC)
)
GO


CREATE TABLE CardModifier(
	CardModifierID int IDENTITY(1,1) NOT NULL,
	CardID int NOT NULL,
	ModifierTypeID int NOT NULL,
	ModifierValue int NULL,
	InstructionText varchar(200) NULL,
CONSTRAINT PK_CardModifier PRIMARY KEY CLUSTERED (CardModifierID ASC)
)
GO


CREATE TABLE CardSet(
	CardSetID int IDENTITY(1,1) NOT NULL,
	CardSetName varchar(20) NOT NULL,
CONSTRAINT PK_CardSet PRIMARY KEY CLUSTERED (CardSetID ASC)
)
GO


CREATE TABLE Category(
	CategoryID int IDENTITY(1,1) NOT NULL,
	CategoryName varchar(50) NOT NULL,
CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (CategoryID ASC)
)
GO


CREATE TABLE ModifierType(
	ModifierTypeID int IDENTITY(1,1) NOT NULL,
	ModifierTypeName varchar(20) NOT NULL,
CONSTRAINT PK_ModifierType PRIMARY KEY CLUSTERED (ModifierTypeID ASC)
)

GO

/* foreign keys */
ALTER TABLE Card  WITH CHECK ADD  CONSTRAINT FK_Card_CardSet FOREIGN KEY(CardSetID)
REFERENCES CardSet (CardSetID)
GO

ALTER TABLE Card CHECK CONSTRAINT FK_Card_CardSet
GO

ALTER TABLE CardCategory  WITH CHECK ADD  CONSTRAINT FK_CardCategory_Card FOREIGN KEY(CardID)
REFERENCES Card (CardID)
GO

ALTER TABLE CardCategory CHECK CONSTRAINT FK_CardCategory_Card
GO

ALTER TABLE CardCategory  WITH CHECK ADD  CONSTRAINT FK_CardCategory_Category FOREIGN KEY(CategoryID)
REFERENCES Category (CategoryID)
GO

ALTER TABLE CardCategory CHECK CONSTRAINT FK_CardCategory_Category
GO

ALTER TABLE CardModifier  WITH CHECK ADD  CONSTRAINT FK_CardModifier_Card FOREIGN KEY(CardID)
REFERENCES Card (CardID)
GO

ALTER TABLE CardModifier CHECK CONSTRAINT FK_CardModifier_Card
GO

ALTER TABLE CardModifier  WITH CHECK ADD  CONSTRAINT FK_CardModifier_ModifierType FOREIGN KEY(ModifierTypeID)
REFERENCES ModifierType (ModifierTypeID)
GO

ALTER TABLE CardModifier CHECK CONSTRAINT FK_CardModifier_ModifierType
GO

/* stored procedures */
CREATE PROCEDURE CardSetSelectAll
AS
	SET NOCOUNT ON

	SELECT CardSetID, CardSetName
	FROM CardSet

GO

CREATE PROCEDURE CardSetInsert (
	@CardSetName varchar(20)
)
AS
	SET NOCOUNT ON

	INSERT INTO CardSet
           (CardSetName)
     VALUES
           (@CardSetName)
GO

CREATE PROCEDURE CardSetDelete (
	@CardSetID int
)
AS
	SET NOCOUNT ON

	DELETE FROM CardSet 
	WHERE CardSetID = @CardSetID
GO


CREATE PROCEDURE CardSetUpdate (
	@CardSetID int,
	@CardSetName varchar(20)
)
AS
	SET NOCOUNT ON

	UPDATE CardSet
	   SET CardSetName = @CardSetName
	WHERE CardSetID = @CardSetID
GO

CREATE PROCEDURE dbo.[CardSetSelectByID](
	@CardSetID int 
)
AS
	SET NOCOUNT ON
	
	SELECT CardSetID
          ,CardSetName
    FROM CardSet
	WHERE CardSetID = @CardSetID
 
GO
		   
CREATE PROCEDURE dbo.[CategorySelectAll]
AS
	SET NOCOUNT ON
	
	SELECT CategoryID
          ,CategoryName
    FROM Category
 
GO
		   
CREATE PROCEDURE dbo.[CategorySelectByID](
	@CategoryID int 
)
AS
	SET NOCOUNT ON
	
	SELECT CategoryID
          ,CategoryName
    FROM Category
	WHERE CategoryID = @CategoryID
 
GO

		   
CREATE PROCEDURE dbo.[CategoryDelete](
	@CategoryID int 
)
AS
	SET NOCOUNT ON
	
	DELETE FROM Category
	WHERE CategoryID = @CategoryID
 
GO

		   
CREATE PROCEDURE dbo.[CategoryInsert](
   @CategoryName varchar(50)
)
AS
	SET NOCOUNT ON
	
	INSERT INTO Category (
         CategoryName
    ) 
	VALUES ( 
         @CategoryName
    )
GO
		   
CREATE PROCEDURE dbo.[CategoryUpdate](
    @CategoryID int
   ,@CategoryName varchar(50)
)
AS
	SET NOCOUNT ON
	
	UPDATE Category SET
        CategoryName = @CategoryName
	WHERE CategoryID = @CategoryID
 
GO

CREATE PROCEDURE dbo.[CardModifierSelectByCardID](
	@CardID int 
)
AS
	SET NOCOUNT ON
	
	SELECT CardModifierID
          ,CardID
          ,CardModifier.ModifierTypeID
          ,ModifierValue
          ,InstructionText
		  ,ModifierTypeName
    FROM CardModifier INNER JOIN ModifierType ON CardModifier.ModifierTypeID = ModifierType.ModifierTypeID
	WHERE CardID = @CardID
 
GO

CREATE PROCEDURE dbo.[CardModifierDelete](
	@CardModifierID int 
)
AS
	SET NOCOUNT ON
	
	DELETE FROM CardModifier
	WHERE CardModifierID = @CardModifierID
 
GO

CREATE PROCEDURE dbo.[CardModifierInsert](
    @CardID int
   ,@ModifierTypeID int
   ,@ModifierValue int
   ,@InstructionText varchar(200)
)
AS
	SET NOCOUNT ON
	
	INSERT INTO CardModifier (
         CardID
        ,ModifierTypeID
        ,ModifierValue
        ,InstructionText
    ) 
	VALUES ( 
         @CardID
        ,@ModifierTypeID
        ,@ModifierValue
        ,@InstructionText
    )

GO
	   
CREATE PROCEDURE dbo.[ModifierTypeSelectAll]
AS
	SET NOCOUNT ON
	
	SELECT ModifierTypeID
          ,ModifierTypeName
    FROM ModifierType
 
GO
		   
CREATE PROCEDURE dbo.[ModifierTypeSelectByID](
	@ModifierTypeID int 
)
AS
	SET NOCOUNT ON
	
	SELECT ModifierTypeID
          ,ModifierTypeName
    FROM ModifierType
	WHERE ModifierTypeID = @ModifierTypeID
 
GO
		   
CREATE PROCEDURE dbo.[ModifierTypeDelete](
	@ModifierTypeID int 
)
AS
	SET NOCOUNT ON
	
	DELETE FROM ModifierType
	WHERE ModifierTypeID = @ModifierTypeID
 
GO
		   
CREATE PROCEDURE dbo.[ModifierTypeInsert](
   @ModifierTypeName varchar(20)
)
AS
	SET NOCOUNT ON
	
	INSERT INTO ModifierType (
         ModifierTypeName
    ) 
	VALUES ( 
         @ModifierTypeName
    )
GO
	   
CREATE PROCEDURE dbo.[ModifierTypeUpdate](
    @ModifierTypeID int
   ,@ModifierTypeName varchar(20)
)
AS
	SET NOCOUNT ON
	
	UPDATE ModifierType SET
        ModifierTypeName = @ModifierTypeName
	WHERE ModifierTypeID = @ModifierTypeID
 
GO
		   
CREATE PROCEDURE dbo.[CardCategorySelectByCardID](
	@CardID int 
)
AS
	SET NOCOUNT ON
	
	SELECT CardCategory.CategoryID,
		CategoryName
    FROM CardCategory
		INNER JOIN Category ON CardCategory.CategoryID = Category.CategoryID
	WHERE CardID = @CardID
 
GO
		   
CREATE PROCEDURE dbo.[CardCategoryDelete](
	@CardID int,
	@CategoryID int 
)
AS
	SET NOCOUNT ON
	
	DELETE FROM CardCategory
	WHERE CardID = @CardID AND CategoryID = @CategoryID
 
GO

		   
CREATE PROCEDURE dbo.[CardCategoryInsert](
    @CardID int
   ,@CategoryID int
)
AS
	SET NOCOUNT ON
	
	INSERT INTO CardCategory (
		 CardID,
         CategoryID
    ) 
	VALUES ( 
		 @CardID,
         @CategoryID
    )
GO

CREATE PROCEDURE dbo.[CardSelectAll]
AS
	SET NOCOUNT ON
	
	SELECT CardID
          ,CardSetID
          ,CardTitle
          ,ImagePath
		  ,CardCost
    FROM Card
 
GO

CREATE PROCEDURE dbo.[CardSelectByID](
	@CardID int 
)
AS
	SET NOCOUNT ON
	
	SELECT CardID
          ,CardSetID
          ,CardTitle
          ,ImagePath
		  ,CardCost
    FROM Card
	WHERE CardID = @CardID
 
GO

CREATE PROCEDURE dbo.[CardDelete](
	@CardID int 
)
AS
	SET NOCOUNT ON

	BEGIN TRANSACTION
		DELETE FROM CardCategory 
		WHERE CardID = @CardID;

		DELETE FROM CardModifier
		WHERE CardID = @CardID;

		DELETE FROM [Card]
		WHERE CardID = @CardID;
	COMMIT TRANSACTION
 
GO

CREATE PROCEDURE dbo.[CardInsert](
    @CardID int output
   ,@CardSetID int
   ,@CardTitle varchar(20)
   ,@ImagePath varchar(50)
   ,@CardCost int
)
AS
	SET NOCOUNT ON
	
	INSERT INTO Card (
         CardSetID
        ,CardTitle
        ,ImagePath
		,CardCost
    ) 
	VALUES ( 
         @CardSetID
        ,@CardTitle
        ,@ImagePath
		,@CardCost
    )
 
	SET @CardID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE dbo.[CardUpdate](
    @CardID int
   ,@CardSetID int
   ,@CardTitle varchar(20)
   ,@ImagePath varchar(50)
   ,@CardCost int
)
AS
	SET NOCOUNT ON
	
	UPDATE Card SET
        CardSetID = @CardSetID
       ,CardTitle = @CardTitle
       ,ImagePath = @ImagePath
	   ,CardCost = @CardCost
	WHERE CardID = @CardID
 
GO

-- sample data
	insert into CardSet (CardSetName)
	values ('Base'), -- id 1
	('Intrigue'); -- id 2

	insert into Category (CategoryName)
	values ('Treasure'),  -- id 1
	('Victory'), -- id 2
	('Action'), -- id 3
	('Attack'), -- id 4
	('Reaction'); -- id 5

	insert into ModifierType (ModifierTypeName)
	values ('+ Cards'), -- id 1
	('+ Actions'), -- id 2
	('+ Buy'), -- id 3
	('+ Coins'), -- id 4
	('Effect'); -- id 5

	insert into [card] (CardSetID, CardTitle, ImagePath, CardCost)
	values (1, 'Copper', 'copper.jpg', 0), -- id 1
		(1, 'Witch', 'witch.jpg', 5); -- id 2

	insert into CardModifier (CardID, ModifierTypeID, ModifierValue, InstructionText)
	values (1, 4, 1, null), -- copper, 1 coin
	(2, 1, 2, null), -- witch, +2 cards
	(2, 5, null, 'Each other player gains a Curse card.'); -- witch, effect

	insert into CardCategory (CardID, CategoryID)
	values (1, 1), -- copper treasure
	(2, 3), -- witch action
	(2, 4); -- witch attack