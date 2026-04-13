DECLARE @id INT = 500

UPDATE Device
SET Enabled = 1
WHERE ID <= @id

UPDATE CustomInputAdapter
SET Enabled = 1
WHERE ID <= @id