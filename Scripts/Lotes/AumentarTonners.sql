select * from dbo.InventariosProductos
where CodigoProducto like '032-T%'

select * from dbo.Productos
where CodigoProducto like '032-T%'

DELETE FROM InventariosProductos
WHERE CodigoProducto IN
('032-T�N-000001 ','032-T�N-000002 ','032-T�N-000003 ', '032-T�N-000004 ')

DELETE FROM Productos
WHERE CodigoProducto IN
('032-T�N-000001 ','032-T�N-000002 ','032-T�N-000003 ', '032-T�N-000004 ')


SELECT * FROM PRODUCTOSMARCAS



--EXEC DBO.InsertarProducto '032-TON-000001',	'032-TON-000001', 'Toner para impresora L�ser Color HP Lasejet CP1025NW  CE310A', NULL, NULL, 58 ,32, 3, 'P', 1, 1, 1, 1, NULL, NULL
--EXEC DBO.InsertarProducto '032-TON-000002',	'032-TON-000002', 'Toner para impresora L�ser Color HP Lasejet CP1025NW  CE311A', NULL, NULL, 58 ,32, 3, 'P', 1, 1, 1, 1		
EXEC DBO.InsertarProducto '032-TON-000003',	'032-TON-000003', 'Toner para impresora L�ser Color HP Lasejet CP1025NW  CE312A', NULL, NULL, 58 ,32, 3, 'P', 1, 1, 1, 1, NULL, NULL
EXEC DBO.InsertarProducto '032-TON-000004',	'032-TON-000004', 'Toner para impresora L�ser Color HP Lasejet CP1025NW  CE313A', NULL, NULL, 58 ,32, 3, 'P', 1, 1, 1, 1, NULL, NULL		
