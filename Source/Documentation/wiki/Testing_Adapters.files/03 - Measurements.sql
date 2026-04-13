DECLARE @phasorCount INT = 10

INSERT INTO
    Phasor(DeviceID, Label, Type, Phase, SourceIndex)
SELECT
    ID AS DeviceID,
    'Phasor' + CAST(IntValue AS VARCHAR(MAX)) AS Label,
    'V' AS Type,
    '+' AS Phase,
    IntValue AS SourceIndex
FROM
    ufn_GenerateIntegers(1, @phasorCount) CROSS JOIN
    Device
ORDER BY
    ID

INSERT INTO
	Measurement(HistorianID, DeviceID, PointTag, SignalTypeID, PhasorSourceIndex, SignalReference, Enabled)
SELECT
	(SELECT ID FROM Historian WHERE Acronym = 'PPA') AS HistorianID,
	ID AS DeviceID,
	Acronym + ':RV' + CONVERT(VARCHAR, IntValue) AS PointTag,
    CASE
        WHEN IntValue <= @phasorCount THEN (SELECT ID FROM SignalType WHERE Acronym = 'VPHM')
        ELSE (SELECT ID FROM SignalType WHERE Acronym = 'VPHA')
    END AS SignalTypeID,
    CASE
        WHEN IntValue <= @phasorCount THEN IntValue
        ELSE IntValue - @phasorCount
    END AS PhasorSourceIndex,
	Acronym + '-PM' + CONVERT(VARCHAR, IntValue) AS SignalReference,
	1 AS Enabled
FROM
	ufn_GenerateIntegers(1, @phasorCount * 2) CROSS JOIN
	Device
ORDER BY
	ID