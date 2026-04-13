INSERT INTO
	Device(NodeID, Acronym, HistorianID, ProtocolID)
SELECT
	(SELECT ID FROM Node) AS NodeID,
	'DEV' + CONVERT(VARCHAR, IntValue) AS Acronym,
	(SELECT ID FROM Historian WHERE Acronym = 'PPA') AS HistorianID,
	(SELECT ID FROM Protocol WHERE Acronym = 'VirtualInput') AS ProtocolID
FROM
	ufn_GenerateIntegers(1, 500)