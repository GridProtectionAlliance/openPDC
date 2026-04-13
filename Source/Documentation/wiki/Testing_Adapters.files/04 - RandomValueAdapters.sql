INSERT INTO
	CustomInputAdapter(NodeID, AdapterName, AssemblyName, TypeName, ConnectionString)
SELECT
	(SELECT ID FROM Node) AS NodeID,
	'RANDOM' + CONVERT(VARCHAR, ID) AS AdapterName,
	'TestingAdapters.dll' AS AssemblyName,
	'TestingAdapters.FrameBasedRandomValueInputAdapter' AS TypeName,
	'MeasurementReportingInterval=2147483647; OutputMeasurements={ FILTER ActiveMeasurements WHERE Device = ''' + Acronym + ''' }' AS ConnectionString
FROM
	Device
ORDER BY
	ID