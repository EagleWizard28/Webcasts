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
	values ('Common'), -- id 1
	('Base'), -- id 2
	('Intrigue'), -- id 3
	('Seaside'), -- id 4
	('Prosperity'), -- id 5
	('Hinterlands'); -- id 6

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
	values (1, 'Copper', 'copper.jpg', 0),
	(1, 'Curse', 'curse.jpg', 0),
	(1, 'Estate', 'estate.jpg', 2),
	(1, 'Silver', 'silver.jpg', 3),
	(1, 'Duchy', 'duchy.jpg', 5),
	(1, 'Gold', 'gold.jpg', 6),
	(1, 'Province', 'province.jpg', 8),
	(2, 'Cellar', 'cellar.jpg', 2),
	(2, 'Chapel', 'chapel.jpg', 2),
	(2, 'Moat', 'moat.jpg', 2),
	(2, 'Chancellor', 'chancellor.jpg', 3),
	(2, 'Village', 'village.jpg', 3),
	(2, 'Woodcutter', 'woodcutter.jpg', 3),
	(2, 'Workshop', 'workshop.jpg', 3),
	(2, 'Bureaucrat', 'bureaucrat.jpg', 4),
	(2, 'Feast', 'feast.jpg', 4),
	(2, 'Gardens', 'gardens.jpg', 4),
	(2, 'Militia', 'militia.jpg', 4),
	(2, 'Moneylender', 'moneylender.jpg', 4),
	(2, 'Remodel', 'remodel.jpg', 4),
	(2, 'Smithy', 'smithy.jpg', 4),
	(2, 'Spy', 'spy.jpg', 4),
	(2, 'Thief', 'thief.jpg', 4),
	(2, 'Throne Room', 'throneroom.jpg', 4),
	(2, 'Council Room', 'councilroom.jpg', 5),
	(2, 'Festival', 'festival.jpg', 5),
	(2, 'Laboratory', 'laboratory.jpg', 5),
	(2, 'Library', 'library.jpg', 5),
	(2, 'Market', 'market.jpg', 5),
	(2, 'Mine', 'mine.jpg', 5),
	(2, 'Witch', 'witch.jpg', 5),
	(2, 'Adventurer', 'adventurer.jpg', 6)

	insert into CardModifier (CardID, ModifierTypeID, ModifierValue, InstructionText)
	values (1, 4, 1, null), -- copper, 1 coin
	(2, 1, 2, null), -- witch, +2 cards
	(2, 5, null, 'Each other player gains a Curse card.'); -- witch, effect

	insert into CardCategory (CardID, CategoryID)
	values (1, 1), -- copper treasure
	(2, 3), -- witch action
	(2, 4); -- witch attack
END