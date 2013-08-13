USE DominionCardTracker
GO

IF OBJECT_ID('DbReset') IS NOT NULL
DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset
AS
BEGIN
	delete from CardCategory;
	delete from CardModifier;
	delete from [Card];
	delete from CardSet;
	delete from CardCategory;
	delete from Category;
	delete from ModifierType;

	DBCC CHECKIDENT('CardSet', RESEED, 0);
	DBCC CHECKIDENT('Category', RESEED, 0);
	DBCC CHECKIDENT('CardModifier', RESEED, 0);
	DBCC CHECKIDENT('ModifierType', RESEED, 0);
	DBCC CHECKIDENT('Card', RESEED, 0);

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
END