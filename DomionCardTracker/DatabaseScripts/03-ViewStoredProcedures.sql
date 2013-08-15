USE DominionCardTracker
GO

CREATE PROCEDURE CardSelectView (
	@CardID int
)
AS
BEGIN
	SELECT CardID
          ,cs.CardSetID
          ,CardTitle
          ,ImagePath
		  ,cs.CardSetName
    FROM [Card] c 
		INNER JOIN CardSet cs ON c.CardSetID = cs.CardSetID
	WHERE c.CardID = @CardID;

	SELECT  c.CategoryID
		   ,CategoryName
	FROM Category c
		INNER JOIN CardCategory cc ON c.CategoryID = cc.CategoryID
	WHERE cc.CardID = @CardID;

	SELECT  CardModifierID
		   ,CardID
		   ,mt.ModifierTypeID
		   ,ModifierValue
		   ,InstructionText
		   ,ModifierTypeName
	FROM CardModifier cm
		INNER JOIN ModifierType mt on cm.ModifierTypeID = mt.ModifierTypeID
	WHERE CardID = @CardID;
END