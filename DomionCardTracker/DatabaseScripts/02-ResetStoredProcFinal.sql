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
	('Base'),
	('Intrigue'),
	('Seaside'),
	('Alchemy'),
	('Prosperity'),
	('Cornucopia'),
	('Hinterlands');

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
	-- base
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
	(2, 'Adventurer', 'adventurer.jpg', 6),
	-- intrigue
	(3, 'Courtyard', 'courtyard.jpg', 2),
	(3, 'Pawn', 'pawn.jpg', 2),
	(3, 'Secret Chamber', 'secretchamber.jpg', 2),
	(3, 'Great Hall', 'greathall.jpg', 3),
	(3, 'Masquerade', 'masquerade.jpg', 3),
	(3, 'Shanty Town', 'shantytown.jpg', 3),
	(3, 'Steward', 'steward.jpg', 3),
	(3, 'Swindler', 'swindler.jpg', 3),
	(3, 'Wishing Well', 'wishingwell.jpg', 3),
	(3, 'Baron', 'baron.jpg', 4),
	(3, 'Bridge', 'bridge.jpg', 4),
	(3, 'Conspirator', 'conspirator.jpg', 4),
	(3, 'Coppersmith', 'coppersmith.jpg', 4),
	(3, 'Ironworks', 'ironworks.jpg', 4),
	(3, 'Mining Village', 'miningvillage.jpg', 4),
	(3, 'Scout', 'scout.jpg', 4),
	(3, 'Duke', 'duke.jpg', 5),
	(3, 'Minion', 'minion.jpg', 5),
	(3, 'Saboteur', 'saboteur.jpg', 5),
	(3, 'Torturer', 'torturer.jpg', 5),
	(3, 'Trading Post', 'tradingpost.jpg', 5),
	(3, 'Tribute', 'tribute.jpg', 5),
	(3, 'Upgrade', 'upgrade.jpg', 5),
	(3, 'Harem', 'harem.jpg', 6),
	(3, 'Nobles', 'nobles.jpg', 6),
	-- seaside
	(4, 'Embargo', 'embargo.jpg', 2),
	(4, 'Haven', 'haven.jpg', 2),
	(4, 'Lighthouse', 'lighthouse.jpg', 2),
	(4, 'Native Village', 'nativevillage.jpg', 2),
	(4, 'Pearl Diver', 'pearldiver.jpg', 2),
	(4, 'Ambassador', 'ambassador.jpg', 3),
	(4, 'Fishing Village', 'fishingvillage.jpg', 3),
	(4, 'Lookout', 'lookout.jpg', 3),
	(4, 'Smugglers', 'smugglers.jpg', 3),
	(4, 'Warehouse', 'warehouse.jpg', 3),
	(4, 'Caravan', 'caravan.jpg', 4),
	(4, 'Cutpurse', 'cutpurse.jpg', 4),
	(4, 'Island', 'island.jpg', 4),
	(4, 'Navigator', 'navigator.jpg', 4),
	(4, 'Pirate Ship', 'pirateship.jpg', 4),
	(4, 'Salvager', 'salvager.jpg', 4),
	(4, 'Sea Hag', 'seahag.jpg', 4),
	(4, 'Treasure Map', 'treasuremap.jpg', 4),
	(4, 'Bazaar', 'bazaar.jpg', 5),
	(4, 'Explorer', 'explorer.jpg', 5),
	(4, 'Ghost Ship', 'ghostship.jpg', 5),
	(4, 'Merchant Ship', 'merchantship.jpg', 5),
	(4, 'Outpost', 'outpost.jpg', 5),
	(4, 'Tactician', 'tactician.jpg', 5),
	(4, 'Treasury', 'treasury.jpg', 5),
	(4, 'Wharf', 'wharf.jpg', 5);



	insert into CardModifier (CardID, ModifierTypeID, ModifierValue, InstructionText)
	values (1, 4, 1, null), -- copper, 1 coin
	(31, 1, 2, null), -- witch, +2 cards
	(31, 5, null, 'Each other player gains a Curse card.'); -- witch, effect

	insert into CardCategory (CardID, CategoryID)
	values (1, 1), -- copper treasure
	(31, 3), -- witch action
	(31, 4); -- witch attack
END