INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(611, 610, 'TSMIReportesListarProductosEnTransitoPorPedido', 'Productos En Transito', 'M', '', NULL, NULL, '', '', 'ListarProductosEnTransitoPorPedido')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 611, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(612, 610, 'TSMIReportesListarComprasProductosReportesPorFechasTipo', 'Listado Por Fechas', 'M', '', NULL, NULL, '', '', 'ListarComprasProductosReportesPorFechasTipo')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 612, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(613, 610, 'TSMIReportesListarComprasProductosReportesPorFechasTipo2', 'Listado Por Tipos', 'M', '', NULL, NULL, '', '', 'ListarComprasProductosReportesPorFechasTipo2')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 613, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(614, 610, 'TSMIReportesListarComprasProductosReportesPorFechasProveedor', 'Listado Por Proveedor', 'M', '', NULL, NULL, '', '', 'ListarComprasProductosReportesPorFechasProveedor')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 614, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(615, 610, 'TSMIReportesListarComprasProductosReportesPorFechasProveedor2', 'Listado Por Proveedor Tipos', 'M', '', NULL, NULL, '', '', 'ListarComprasProductosReportesPorFechasProveedor2')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 615, 1, 1, 1)

--NUEVOS  02/01/2012
--
INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(616, 610, 'TSMIListarCompraProductoCuentasPorCobrarReporte', 'Cuentas Por Cobrar', 'M', '', NULL, NULL, '', '', 'ListarCompraProductoCuentasPorCobrarReporte')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 616, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(617, 610, 'TSMIListarCompraProductoCuentasPorPagarReporte', 'Cuentas Por Pagar', 'M', '', NULL, NULL, '', '', 'ListarCompraProductoCuentasPorPagarReporte')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 617, 1, 1, 1)
--


--NUEVOS 17/05/2011
INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(640, 600, 'TSMIReportesInventarios', 'Inventario', 'M', '', NULL, NULL, '', '', NULL)
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 640, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(641, 640, 'TSMIReportesListarKardexProductoDetalladoReporte', 'Kardex Valorado Detallado de Productos', 'M', '', NULL, NULL, '', '', 'ListarKardexProductoDetalladoReporte')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 641, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(642, 640, 'TSMIReportesListarKardexValorado', 'Kardex Valorado de Productos', 'M', '', NULL, NULL, '', '', 'ListarKardexValorado')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 642, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(643, 640, 'TSMIReportesListarHistorialInventarioPorFecha', 'Kardex de Productos', 'M', '', NULL, NULL, '', '', 'ListarHistorialInventarioPorFecha')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 643, 1, 1, 1)

--select *
--from SistemaMenuPrincipal
--where NombreElementoMenu like '%Contabilidad%'

--select *
--from SistemaMenuPrincipal
--where CodigoElementoMenu >=630


--REPORTE DE VENTAS 01/02/2012
INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(621, 620, 'TSMIListarVentasProductosReportesPorFechasTipo', 'Listado Por Fechas', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorFechasTipo')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 621, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(622, 620, 'TSMIListarVentasProductosReportesPorFechasTipo2', 'Listado Por Tipos', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorFechasTipo2')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 622, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(623, 620, 'TSMIListarVentasProductosReportesPorFechasCliente', 'Listado Por Clientes', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorFechasCliente')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 623, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(624, 620, 'TSMIListarVentasProductosReportesPorFechasCliente2', 'Listado Por Clientes Tipos', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorFechasCliente2')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 624, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(625, 620, 'TSMIListarVentasProductosReportesPorCreditosFechasCliente', 'Listado Por Creditos', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorCreditosFechasCliente')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 625, 1, 1, 1)

INSERT INTO SistemaMenuPrincipal(CodigoElementoMenu, CodigoElementoMenuPadre, NombreElementoMenu, TextoElementoMenu, CodigoTipoElementoMenu, URLImagenElementoMenu, NombreBotonBarra, NombreBotonBarraPadre, TextoBotonBarra, URLImagenBotonBarra, FuncionEnlace) VALUES(626, 620, 'TSMIListarVentasProductosReportesPorCreditosFechasCliente2', 'Listado Creditos por Clientes', 'M', '', NULL, NULL, '', '', 'ListarVentasProductosReportesPorCreditosFechasCliente2')
INSERT INTO SistemaGruposMenuPrincipal(CodigoGrupoSistema, CodigoElementoMenu, Visible, Activo, IncluirBotonBarra) VALUES(1, 626, 1, 1, 1)


SELECT * from SistemaMenuPrincipal 
WHERE TextoElementoMenu LIKE '%Venta%'
select * from usuarios