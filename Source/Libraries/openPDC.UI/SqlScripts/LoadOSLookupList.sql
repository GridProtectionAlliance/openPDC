SELECT ID, Name
FROM OutputStream
WHERE NodeID = @nodeID
ORDER BY Name;