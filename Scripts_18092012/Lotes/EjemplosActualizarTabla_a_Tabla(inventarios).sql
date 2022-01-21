select * from comprasproductos
select * from CotizacionVentasProductos

select * from VentasFacturas
select * from PCsConfiguraciones
select * from Agencias



select * from Usuarios
select * from SistemaGruposUsuarios
select * from UsuariosAgenciasMenuPrincipal
select * from UsuariosAgenciasPermisosInterfaces



delete from SistemaGruposUsuarios where CodigoUsuario <> 1
delete from UsuariosAgenciasPermisosInterfaces where CodigoUsuario <> 1
delete from UsuariosAgenciasMenuPrincipal where CodigoUsuario <> 1
delete from Usuarios where CodigoUsuario <> 1




UPDATE TABLEA
SET     b = TABLEB.b1,
c = TABLEB.c1,
d = TABLEB.d1
FROM TABLEA, TABLEB
WHERE TABLEA.a = TABLEB.a1
AND TABLEB.e1 > 40
GO

select * from temporal1
select * from temporal2

UPDATE temporal2
SET	numero = temporal1.numero
from temporal1, temporal2
where temporal1.codigo = temporal2.codigo
go

select * from temporal1
select * from temporal2

drop table temporal1
go

create table temporal1
(
	codigo int identity(1,1) primary key,
	numero char(5)
)
go

insert into temporal1(numero) values ('1')
insert into temporal1(numero) values ('2')
insert into temporal1(numero) values ('3')
insert into temporal1(numero) values ('4')
insert into temporal1(numero) values ('5')

drop table temporal2
go

create table temporal2
(
	codigo int identity(1,1) primary key,
	numero char(5)
)
go


insert into temporal2(numero) values ('6')
insert into temporal2(numero) values ('7')
insert into temporal2(numero) values ('8')
insert into temporal2(numero) values ('9')
insert into temporal2(numero) values ('10')