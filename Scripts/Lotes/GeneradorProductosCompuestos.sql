update Productos
	SET NombreProducto = 'MODULO-INTERRUPTOR P/TIMBRE MARFIL TECLON'
WHERE CodigoProducto = '010-MOD-000020 '

select * from productos
WHERE ProductoSimple = 0
--AND NOmbreProducto like '%SCHUCO%'
SELECT * FROM ProductosTipos
select * from productosunidades

select  PT.CodigoTipoProducto, PT.NombreTipoProducto, P.CodigoProducto, P.CodigoProductoFabricante, P.NombreProducto, PC.Cantidad, P2.NombreProducto AS NombreProductoComponente, P2.CodigoProductoFabricante
from dbo.ProductosTipos PT
INNER JOIN dbo.Productos P
ON PT.CodigoTipoProducto =P.CodigoTipoProducto
INNER JOIN ProductosCompuestos PC
ON P.CodigoProducto = PC.CodigoProducto
INNER JOIN dbo.Productos P2
ON PC.CodigoProductoComponente = P2.CodigoProducto
where p.NombreProducto like '%DONNA%'
--where CodigoTipoProductoPadre in (66, 67, 68, 88)

SELECT P.CodigoProducto, P.NombreProducto, PC.CodigoProductoComponente
FROM Productos P
inner join ProductosCompuestos PC
ON P.CodigoProducto = PC.CodigoProducto
where P.CodigoProducto in ('010-TAP-000001', '010-TAP-000002')


WHERE PT.CodigoTipoProducto IN ('010-TAP-000001', '010-TAP-000002')


select * from ProductosTipos
where CodigoTipoProductoPadre in (66, 67, 68, 88)

select * from ProductosTipos
where CodigoTipoProducto in (66, 67, 68, 88)

select * 
from productos
where CodigoTipoProducto = 10
order by nombreproducto
--TAPA+BASTIDOR 3 MODULO BLANCO
SELECT * FROM Productos WHERE NombreProducto LIKE '%TAPA+BASTIDO%'



--MARCOS JONICA 
--'010-MAR-000001', '010-MAR-000002', '010-MAR-000003'
--TORNILLO KALOP PLACAS CIVIL+JONICA+ZEN+DONNA TORNILLOS PARA ENSAMBLDO
--'010-TOR-000001 '
--MODULO-TAPA CIEGA BLANCO
--'010-MOD-000048', '010-MOD-000049', '010-MOD-000052'
--TAPA+BASTIDOR 3 MODULO BLANCO, MARFIL
--'010-TAP-000001', '010-TAP-000002'
--MODULOS TAPAS EN SU GAMA DE COLORES
--'011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046'
--BASTIDOR -3 MODULOS GRAFITO JONICA + CIVIL
--'012-BAS-000001 '
--CUBRE BASTIDOR SISTEMA MODULAR KALOP
--'012-CUB-000001' 

select * from dbo.ProductosMarcas
select * from dbo.ProductosUnidades
select * from dbo.ProductosPropiedades
select * from dbo.ProductosDescripcion

DECLARE @TProductos	TABLE
(
	CodigoProducto		CHAR(15),
	CodigoFabricante	CHAR(15),
	NombreProducto		VARCHAR(50)
)



CREATE TABLE X_REPLACEMENTS (
string	 NVARCHAR(100),
replacement	NVARCHAR(100));

INSERT INTO X_REPLACEMENTS VALUES ('abc','123');
INSERT INTO X_REPLACEMENTS VALUES ('xxx','666');

DECLARE @v_str NVARCHAR(1000);
SET @v_str = 'abc..xabc xxx xyz';

SELECT @v_str = REPLACE(@v_str,string,replacement)
FROM X_REPLACEMENTS;

PRINT @v_str;
select * from X_REPLACEMENTS


placa interrruptor simple BLANCO NORDIDO civil - MODULO BLANCO
PLACA NOMBRE MODULO  SIMPLE  COLOR TAPA LINEA - MODULO COLOR MODULO MARCO [COLOR MARCO]



PLACA MIXTA INTERRUPTOR + ENCHUFE BABY CIVIL MODULO BLANCO 


CLASIFICADOR
	ENCHUFE CON TIERRA + TELEFONO
	ENCHUFE CON TIERRA + TV CABLE






update Productos set NombreProducto = rtrim(ltrim(NombreProducto))
update productos set nombreproducto = 'MODULO-INTERRUPTOR BIPOLAR INVERSO BLANCO' where codigoproducto = '010-MOD-000031 '

select * from productos where codigoproducto = '010-MOD-000031 '
--MODULOS
SELECT P.CodigoProducto, P.NombreProducto, 
		--P.CodigoProductoFabricante, 
		 CASE WHEN P.NombreProducto like '%1/2 TECLON%' THEN 1.5
			  WHEN P.NombreProducto like '%[^1/2] TECLON%' THEN 3 
			  WHEN P.NombreProducto like '%SCHUCO%' THEN 2 ELSE 1 END AS CantidadEspacios,
		 CASE WHEN P.NombreProducto like '%BLANCO%' THEN 'BLANCO'
			  WHEN P.NombreProducto like '%MARFIL%' THEN 'MARFIL'
			  WHEN P.NombreProducto like '%NEGRO%' THEN 'NEGRO'
			  ELSE 'BLANCO' END AS Color,
			  LTRIM(RTRIM(REPLACE(REPLACE(REPLACE( REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(P.NombreProducto,'BLANCO',''),'MARFIL', '') ,'NEGRO', ''), 'MODULO',''),'-',''),'TECLON',''),'1/2',''),'SENCILLO','') )) AS NombreModuloArregaldo
		 
		--LEFT(P.NombreProducto, LEN(P.NombreProducto) - CHARINDEX(' ', REVERSE(P.NombreProducto))) as otro,
		--PT.NombreTipoProducto			
FROM Productos P
--INNER JOIN dbo.ProductosTipos PT
--ON PT.CodigoTipoProducto = P.CodigoTipoProducto
WHERE P.CodigoProducto NOT IN ('010-MAR-000001', '010-MAR-000002', '010-MAR-000003', '010-TOR-000001 ','010-MOD-000048', '010-MOD-000049', '010-MOD-000052',
'010-TAP-000001', '010-TAP-000002', '011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046',
'012-BAS-000001 ','012-CUB-000001 ' )
and P.ProductoSimple = 1
and P.CodigoTipoProducto = 10
ORDER BY  CantidadEspacios,  NombreModuloArregaldo, Color



--MODULOS


--TAPAS
select CodigoProducto, CodigoProductoFabricante, NombreProducto, 
		CASE WHEN NombreProducto LIKE '%CIVIL%' THEN 'CIVIL'
		WHEN NombreProducto LIKE '%JONICA%' THEN 'JONICA'		
		ELSE 'ZEN' END AS Linea,
		rtrim(ltrim(REPLACE(REPLACE(REPLACE(REPLACE(NombreProducto,'TAPA-3 MODULOS ',''), 'ZEN',''),'JONICA',''),'CIVIL',''))) AS NombreColor
from Productos
where CodigoProducto in ('011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046')
ORDER BY 4, 3


--TAPA-3 MODULOS ZEN METAL PLATA


--TORNILLO KALOP PLACAS CIVIL+JONICA+ZEN+DONNA TORNILLOS PARA ENSAMBLADO
SELECT  CodigoProducto, CodigoProductoFabricante, NombreProducto
FROM Productos
WHERE CodigoProducto IN ('010-TOR-000001 ')


--MODULO-TAPA CIEGA BLANCO
SELECT  CodigoProducto, CodigoProductoFabricante, NombreProducto
FROM Productos
WHERE CodigoProducto IN ('010-MOD-000048', '010-MOD-000049', '010-MOD-000052')

--BASTIDOR
SELECT  CodigoProducto, CodigoProductoFabricante, NombreProducto
FROM Productos
WHERE CodigoProducto IN ('012-BAS-000001 ')




--MARCOS PARA JONICA
SELECT  CodigoProducto, CodigoProductoFabricante, NombreProducto
FROM Productos
WHERE CodigoProducto IN ('010-MAR-000001', '010-MAR-000002', '010-MAR-000003')


SELECT PT.NombreTipoProducto, PT.NombreCortoTipoProducto, P.CodigoProducto, P.CodigoProductoFabricante, P.NombreProducto 
FROM Productos P 
INNER JOIN ProductosTipos PT
ON P.CodigoTipoProducto = PT.CodigoTipoProducto
WHERE ProductoSimple = 0
ORDER BY NombreTipoProducto, NombreProducto

select * 
from Productos 
where NombreProducto like '%DONNA%'

SELECT P.CodigoProducto, P.CodigoProductoFabricante, P.NombreProducto, CASE WHEN p.NombreProducto like '%1/2 TECLON%' THEN 1.5 WHEN p.NombreProducto like '%[^1/2] TECLON%' THEN 3 WHEN p.NombreProducto like '%SCHUCO%' THEN 2 ELSE 1 END AS CantidadEspacios
FROM Productos P
--INNER JOIN dbo.ProductosTipos PT
--ON PT.CodigoTipoProducto = P.CodigoTipoProducto
WHERE P.CodigoProducto NOT IN ('010-MAR-000001', '010-MAR-000002', '010-MAR-000003')
AND P.CodigoProducto NOT IN ('010-TOR-000001 ')
AND P.CodigoProducto NOT IN ('010-MOD-000048', '010-MOD-000049', '010-MOD-000052')
AND P.CodigoProducto NOT IN ('010-TAP-000001', '010-TAP-000002')
AND P.CodigoProducto NOT IN ('011-TAP-000001', '011-TAP-000002', '011-TAP-000003', '011-TAP-000004', '011-TAP-000005', '011-TAP-000006', '011-TAP-000007', '011-TAP-000008', '011-TAP-000009', '011-TAP-000010', '011-TAP-000011', '011-TAP-000012', '011-TAP-000013', '011-TAP-000014', '011-TAP-000015', '011-TAP-000016', '011-TAP-000017', '011-TAP-000018', '011-TAP-000019', '011-TAP-000020', '011-TAP-000021', '011-TAP-000022', '011-TAP-000023', '011-TAP-000024', '011-TAP-000025', '011-TAP-000026', '011-TAP-000027', '011-TAP-000028', '011-TAP-000029', '011-TAP-000030', '011-TAP-000031', '011-TAP-000032', '011-TAP-000033', '011-TAP-000034', '011-TAP-000035', '011-TAP-000036', '011-TAP-000037', '011-TAP-000038', '011-TAP-000039', '011-TAP-000040', '011-TAP-000041', '011-TAP-000042', '011-TAP-000043', '011-TAP-000044', '011-TAP-000045', '011-TAP-000046')
AND P.CodigoProducto NOT IN ('012-BAS-000001 ')
AND P.CodigoProducto NOT IN ('012-CUB-000001 ')
and P.ProductoSimple = 1
and P.CodigoTipoProducto = 10
--AND  p.NombreProducto like '%1/2 TECLON%'
--and p.NombreProducto like '%[^1/2] TECLON%'
--and p.NombreProducto like '%SCHUCO%'
ORDER BY 4, NombreProducto 




SELECT P.*
FROM Productos P
where p.NombreProducto like '%SCHUCO%'
OR p.NombreProducto like '%[^1/2] TECLON%'

SELECT * FROM  ProductosCompuestos WHERE [CodigoProductoComponente] = '075-PLA-000001 '


MODULO-INTERRUPTOR SENCILLO BLANCO TECLON
MODULO-INTERRUP. CONMUTADOR MARFIL 1/2 TECLON