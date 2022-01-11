USE [Rinku]
GO
/****** Object:  Table [dbo].[cEmpleados]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cEmpleados](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [char](5) NULL,
	[Nombre] [varchar](150) NULL,
	[IdRol] [int] NULL,
	[IdTipo] [int] NULL,
	[SueldoHora] [money] NULL,
	[JornadaLaboral] [int] NULL,
	[Situacion] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuracion]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracion](
	[AComiJL] [bit] NULL,
	[ComiJL] [money] NULL,
	[ABonoCh] [bit] NULL,
	[BonoCh] [money] NULL,
	[ABonoCarga] [bit] NULL,
	[BonoCarga] [money] NULL,
	[ISR] [money] NULL,
	[ISRSobrePasa] [money] NULL,
	[ISRSobrePorc] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DB_Errors]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DB_Errors](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[ErrorNumber] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorLine] [int] NULL,
	[ErrorProcedure] [varchar](max) NULL,
	[ErrorMessage] [varchar](max) NULL,
	[ErrorDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Cargador] [varchar](5) NULL,
	[Entregas] [int] NULL,
	[Horas] [int] NULL,
	[Fecha] [date] NULL,
	[Registro] [date] NULL,
	[Situacion] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDMov] [int] NULL,
	[Codigo] [varchar](5) NULL,
	[Sueldo] [money] NULL,
	[Adicional] [money] NULL,
	[Bono] [money] NULL,
	[Vales] [money] NULL,
	[ISR] [money] NULL,
	[Tipo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](80) NULL,
	[BonoHora] [money] NULL,
	[PagoEntregaPaq] [bit] NULL,
	[Situacion] [char](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](80) NULL,
	[ValeDespensa] [money] NULL,
	[Situacion] [char](1) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cEmpleados] ADD  CONSTRAINT [DF_cEmpleados_SueldoHora]  DEFAULT ((0.00)) FOR [SueldoHora]
GO
ALTER TABLE [dbo].[cEmpleados] ADD  CONSTRAINT [DF_cEmpleados_JoirnadaLaboral]  DEFAULT ((0)) FOR [JornadaLaboral]
GO
ALTER TABLE [dbo].[Configuracion] ADD  CONSTRAINT [DF_Table_1_ComiJL]  DEFAULT ((0)) FOR [AComiJL]
GO
ALTER TABLE [dbo].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_ABonoCh]  DEFAULT ((0)) FOR [ABonoCh]
GO
ALTER TABLE [dbo].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_ABonoCarga]  DEFAULT ((0)) FOR [ABonoCarga]
GO
ALTER TABLE [dbo].[Movimientos] ADD  CONSTRAINT [DF_Movimientos_Ingreso]  DEFAULT (CONVERT([date],getdate())) FOR [Registro]
GO
/****** Object:  StoredProcedure [dbo].[c_spCalculoNomina]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Realiza el calculo de nomina
CREATE PROCEDURE [dbo].[c_spCalculoNomina]
@FechaIni char(10),
@FechaFin Char(10)
as

set nocount on
SET DateFormat ymd


BEGIN TRY

IF OBJECT_ID('tempdb..#TmpNommina') IS NOT NULL  DROP TABLE #TmpNommina

declare @BonoAdic money,@BonochAuxCH as money,@BonochAuxCa as money,@ISR money,@ISRporc money,@ISRm money,@ultimoDiaMes int

Set @ultimoDiaMes=day(Cast(@FechaFin as date))


-----------CHECA SI PAGA EL BONO ADICIONAL Y BONO A AUXILIARES ASI COMO % DE ISR
Select @BonoAdic=case when AComiJL=1 then ComiJL else 0 end,  --bono adicional
	@BonochAuxCH=case when ABonoCh=1 then BonoCh else 0 end,  --bono Auxiliares (choferes)
	@BonochAuxCa=case when ABonoCarga=1 then BonoCarga else 0 end,  --bono Auxiliares (Cargadores)
	@ISR=ISR,@ISRporc=ISRSobrePorc,@ISRm=ISRSobrePasa ----ISR
from Configuracion e with(nolock)

--------------------------
------LISTADO DE EMPLEADOS Activos, calcula el sueldo y vales de despensa
Select e.Codigo,e.Nombre,@ultimoDiaMes*(e.SueldoHora*e.JornadaLaboral) as Sueldo,Cast(0 as money) as Adicional,Cast(0 as money) as BonoxHora,
	(@ultimoDiaMes*(e.SueldoHora*e.JornadaLaboral))*(t.ValeDespensa/100) as Vales,Cast(0 as money) as SubTotal,
	Cast(0 as money) as ISR,Cast(0 as money) as SueldoTotal,IdRol,r.Nombre as NomRol,IdTipo
Into #TmpNommina from cEmpleados e with(nolock)
inner join Rol r with(nolock) on e.IdRol=r.ID
inner join Tipo t with(nolock) on e.IdTipo=t.ID
Where e.Situacion<>'B'

---------------------------------------
---CALCULA BONOS (choferes)
UPDATE t
SET t.Adicional=case  --bono por entrega
			when r.PagoEntregaPaq=1 then t.Adicional+(m.TEntregas*@BonoAdic)
			else t.Adicional+0
			End,
	t.BonoxHora=t.BonoxHora+(m.THoras*r.BonoHora) --Bono por hora
FROM #TmpNommina t
INNER JOIN
    (
	   SELECT m1.codigo,sum(m1.Entregas) as TEntregas,sum(m1.Horas) as THoras
	   FROM   Movimientos m1
	   Where m1.Fecha between Cast(@FechaIni as date) and Cast(@FechaFin as date) and m1.Situacion<>'B'
	   GROUP  BY Codigo 
    ) m
    ON t.Codigo=m.Codigo
inner join Rol r with(nolock) on t.IdRol=r.ID
---------------------------------------
---CALCULA BONOS (cargadores)
UPDATE t
SET t.Adicional=case  --bono por entrega
			when r.PagoEntregaPaq=1 then t.Adicional+(m.TEntregas*@BonoAdic)
			else t.Adicional+0
			End,
	t.BonoxHora=t.BonoxHora+(m.THoras*r.BonoHora) --Bono por hora
FROM #TmpNommina t
INNER JOIN
    (
	   SELECT m1.Cargador,sum(m1.Entregas) as TEntregas,sum(m1.Horas) as THoras
	   FROM   Movimientos m1
	   Where m1.Fecha between Cast(@FechaIni as date) and Cast(@FechaFin as date) and m1.Situacion<>'B'
	   GROUP  BY Cargador 
    ) m
    ON t.Codigo=m.Cargador
inner join Rol r with(nolock) on t.IdRol=r.ID
---------------------------------------
---CALCULA BONOS auxiliares(choferes)
UPDATE t
SET --t.Adicional = m.TEntregas*@BonoAdic, --bono por entrega
	t.BonoxHora=t.BonoxHora+(m.THoras*@BonochAuxCH) --Bono por hora
FROM #TmpNommina t
INNER JOIN
    (
	   SELECT m1.Codigo,sum(m1.Entregas) as TEntregas,sum(m1.Horas) as THoras
	   FROM   Movimientos m1
	   Where m1.Fecha between Cast(@FechaIni as date) and Cast(@FechaFin as date) and m1.Situacion<>'B'
	   GROUP  BY Codigo 
    ) m
    ON t.Codigo=m.Codigo
inner join Rol r with(nolock) on t.IdRol=r.ID and r.BonoHora=0
---------------------------------------
---CALCULA BONOS auxiliares(cargador)
UPDATE t
SET --t.Adicional = m.TEntregas*@BonoAdic, --bono por entrega
	t.BonoxHora=t.BonoxHora+(m.THoras*@BonochAuxCH) --Bono por hora
FROM #TmpNommina t
INNER JOIN
    (
	   SELECT m1.Cargador,sum(m1.Entregas) as TEntregas,sum(m1.Horas) as THoras
	   FROM   Movimientos m1
	   Where m1.Fecha between Cast(@FechaIni as date) and Cast(@FechaFin as date) and m1.Situacion<>'B'
	   GROUP  BY Cargador 
    ) m
    ON t.Codigo=m.Cargador
inner join Rol r with(nolock) on t.IdRol=r.ID and r.BonoHora=0
-------------------
--DESCUENTO DE ISR
update t
set t.ISR=case 
			when (t.Sueldo+t.Adicional+t.BonoxHora+t.Vales)<=@ISRm then (t.Sueldo+t.Adicional+t.BonoxHora+t.Vales)*(@ISR/100)
			else (t.Sueldo+t.Adicional+t.BonoxHora+t.Vales)*(@ISRporc/100)
			End,
		t.SubTotal=(t.Sueldo+t.Adicional+t.BonoxHora+t.Vales)
From #TmpNommina t
inner join Tipo r with(nolock) on t.IdTipo=r.ID
-----------------
--SUELDO A PAGAR
update #TmpNommina set SueldoTotal=SubTotal-ISR

-----Lista la nomina
select Codigo,Nombre,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(Sueldo  AS MONEY), 1))as Sueldo,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(Adicional  AS MONEY), 1))as Adicional,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(BonoxHora  AS MONEY), 1))as BonoxHora,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(Vales AS MONEY), 1))as Vales,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(SubTotal  AS MONEY), 1))as SubTotal,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(ISR  AS MONEY), 1))as ISR,
	CONVERT(VARCHAR,CONVERT(VARCHAR, CAST(SueldoTotal  AS MONEY), 1))as SueldoTotal,IdRol,NomRol,IdTipo 
	from #TmpNommina

Truncate Table #TmpNommina
Drop Table #TmpNommina

END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[c_spConfiguracion]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[c_spConfiguracion] 
	@Opc int,
	@AComiJL char(1)=NULL,
	@ComiJL varchar(15)=NULL,
	@ABonoCh char(1)=NULL,
	@BonoCh varchar(15)=NULL,
	@ABonoCarga char(1)=NULL,
	@BonoCarga varchar(15)=NULL,
	@ISR varchar(8)=NULL,
	@ISRSobrePorc varchar(8)=NULL,
	@ISRSobrePasa varchar(15)=NULL,
	@Filtro varchar(100)=null
AS

set nocount on
SET DateFormat ymd

Declare @lCont int,@sql nvarchar(max)

BEGIN TRY

--AGREGA UNO NUEVO O ACTUALIZA  
 if @Opc=1 
 Begin
		select @lCont=Count(*) from Configuracion with(nolock)

		if (@lCont=0)
		Begin
			Insert Configuracion(AComiJL,ComiJL,ABonoCh,BonoCh,AbonoCarga,BonoCarga,ISR,ISRSobrePorc,ISRSobrePasa)
			values(Cast(@AComiJL as bit), Cast(@ComiJL as money), Cast(@ABonoCh as bit), Cast(@BonoCh as money), Cast(@ABonoCarga as bit), Cast(@BonoCarga as money),
						Cast(@ISR as money), Cast(@ISRSobrePorc as money), Cast(@ISRSobrePasa as money))

		End
		Else
		Begin
 			Update Configuracion set AComiJL=Cast(@AComiJL as bit),ComiJL=Cast(@ComiJL as money),ABonoCh=Cast(@ABonoCh as bit),BonoCh=Cast(@BonoCh as money),
									AbonoCarga=Cast(@ABonoCarga as bit),BonoCarga=Cast(@BonoCarga as money),ISR=Cast(@ISR as money),
									ISRSobrePorc=Cast(@ISRSobrePorc as money),ISRSobrePasa=Cast(@ISRSobrePasa as money)
		End
 End

 if @Opc=2
 Begin
	Select AComiJL,ComiJL,ABonoCh,BonoCh,AbonoCarga,BonoCarga,ISR,ISRSobrePorc,ISRSobrePasa From Configuracion with(nolock)
 End

END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[c_spEmpleado]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[c_spEmpleado] 
	@Opc int,
	@Id int=null,
	@Codigo varchar(5)=NULL,
	@Nombre varchar(150)=NULL,
	@IdRol varchar(5)=NULL,
	@IdTipo varchar(5)=NULL,
	@Sueldo varchar(15)=NULL,
	@Jornada varchar(5)=NULL,
	@Filtro varchar(100)=null
AS

set nocount on
SET DateFormat ymd

Declare @lCodigo varchar(5),@sql nvarchar(max)

BEGIN TRY

--AGREGA UNO NUEVO O ACTUALIZA  
 if @Opc=1 
 Begin
		if  @id is null
		Begin
			set @id=0
		End

		Select @Codigo=right('00000'+ltrim(rtrim(@Codigo)),5)

		if NOT EXISTS (select Codigo from cEmpleados with(nolock) where ID=@Id)
		Begin
			Insert cEmpleados(Codigo,Nombre,IdRol,IdTipo,SueldoHora,JornadaLaboral,Situacion)
			values(@Codigo,UPPER(@Nombre),@IdRol,@IdTipo,Cast(@Sueldo as money),Cast(@Jornada as int),'')

			DBCC checkident ('cEmpleados', reseed)
		End
		Else
		Begin
 			Update cEmpleados set Nombre=UPPER(@Nombre),IdRol=@IdRol,IdTipo=@IdTipo,SueldoHora=Cast(@Sueldo as money),JornadaLaboral=Cast(@Jornada as int)
			Where ID=@Id
		End
 End
 ---BUSCA  X Codigo
 if @Opc=2 
 Begin
	Select e.ID,e.Codigo,e.Nombre,e.IdRol,r.Nombre as Rol,e.IdTipo,t.Nombre as Tipo,format(e.SueldoHora,'N','es-us') as SueldoHora,e.JornadaLaboral as Jornada,e.Situacion
	from cEmpleados e with(nolock) 
	Inner join Rol r with(nolock) on r.id=e.idRol
	Inner join Tipo t with(nolock) on t.id=e.idTipo
	Where e.Codigo=@Codigo
 end
 ---BORRA 
 if @Opc=3 
 Begin
	Update cEmpleados Set Situacion=Case
								When Situacion='B' then ''
								Else 'B'
								End
	Where ID=@Id
 end
---TODOS LOS REGISTROS 
 if @Opc=4 
 Begin
 	Select e.ID,e.Codigo,e.Nombre,e.IdRol,r.Nombre as Rol,e.IdTipo,t.Nombre as Tipo,format(SueldoHora,'N','es-us') as SueldoHora,e.JornadaLaboral as Jornada,
			Situacion=Case
							when e.Situacion='B' then 'Borrado'
							else ''
					end
	from cEmpleados e with(nolock)
	Inner join Rol r with(nolock) on r.id=e.idRol
	Inner join Tipo t with(nolock) on t.id=e.idTipo
 end
 ---OBTIENE EL ULTIMO CODIGO
 if @Opc=5 
 Begin
	Set @Codigo='00001'
	Select Top 1 @Codigo=right('00000'+ltrim(rtrim(Cast(Cast(Codigo as int)+1 as varchar))),5)
	From cEmpleados with(nolock)
	Order by Codigo Desc

	Select ltrim(rtrim(@Codigo))
 end

if @Opc=6
 Begin
 	Select e.Codigo,e.Nombre,r.Nombre as Rol
	from cEmpleados e with(nolock)
	Inner join Rol r with(nolock) on r.id=e.idRol and r.ID!=@Filtro
	Inner join Tipo t with(nolock) on t.id=e.idTipo
	Where e.Situacion!='B'

 end


END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[c_spMovimiento]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------CREACION: 09-01-2022
---------PROCEDIMIENTO RELAZIONADO CON LA TABLA MOVIMIENTOS
---------(INSERTAR, EDITAR,BUSQUEDAS)

CREATE PROCEDURE [dbo].[c_spMovimiento] 
	@Opc int,
	@Id int=null,
	@Codigo varchar(5)=NULL,
	@Cargador varchar(5)=NULL,
	@Entrega varchar(10)=NULL,
	@Fecha varchar(10)=NULL,
	@Horas varchar(5)=NULL,
	@Sueldo varchar(15)=NULL,
	@Adicional varchar(15)=NULL,
	@Bono varchar(15)=NULL,
	@Vale varchar(15)=NULL,
	@ISR varchar(15)=NULL,
	@Filtro varchar(100)=null
AS

set nocount on
SET DateFormat ymd

Declare @lCodigo varchar(5)

BEGIN TRY

--AGREGA UNO NUEVO O ACTUALIZA  
 if @Opc=1 
 Begin
		if  @id is null
		Begin
			set @id=0
		End

		Select @Codigo=right('00000'+ltrim(rtrim(@Codigo)),5)
		Select @Cargador=right('00000'+ltrim(rtrim(@Cargador)),5)

		if NOT EXISTS (select Codigo from Movimientos with(nolock) where ID=@Id)
		Begin
			Insert Movimientos(Codigo,Cargador,Entregas,Horas,Fecha,Situacion)
			values(@Codigo,@Cargador,Cast(@Entrega as int),@Horas,Cast(@Fecha as date),'')

			DBCC checkident ('Movimientos', reseed)
		End
		Else
		Begin
 			Update Movimientos set Codigo=@Codigo,Cargador=@Cargador,Entregas=Cast(@Entrega as int),Horas=@Horas,Fecha=Cast(@Fecha as date)
			Where ID=@Id
		End
 End
 ---BORRA 
 if @Opc=3 
 Begin
	Update Movimientos Set Situacion=Case
								When Situacion='B' then ''
								Else 'B'
								End
	Where ID=@Id
 end
---TODOS LOS REGISTROS 
 if @Opc=4 
 Begin
 	Select m.ID,m.Codigo,e.Nombre,m.Cargador,l.Nombre as NomCargador,m.Entregas,m.Horas,Convert(char(10),m.Fecha,103) as Fecha,
			Situacion=Case
							when m.Situacion='B' then 'Borrado'
							else ''
					end
	from Movimientos m with(nolock)
	Inner join cEmpleados e with(nolock) on  m.Codigo=e.Codigo
	Inner join cEmpleados l with(nolock) on  m.Cargador=l.Codigo
	where Registro=Cast(@Fecha as date)

 end


END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[c_spRol]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[c_spRol] 
	@Opc int,
	@Id int=null,
	@Nombre varchar(90)=NULL,
	@Bono varchar(15)=NULL,
	@BonoPaq varchar(1)=NULL,
	@Filtro varchar(100)=null
AS

set nocount on
SET DateFormat ymd

BEGIN TRY

--AGREGA UNO NUEVO O ACTUALIZA  
 if @Opc=1 
 Begin
		if  @id is null
		Begin
			set @id=0
		End

		if NOT EXISTS (select Nombre from Rol with(nolock) where ID=@Id)
		Begin
			Insert Rol(Nombre,BonoHora,PagoEntregaPaq,Situacion)
			values(UPPER(@Nombre),Cast(@BonoPaq as bit),Cast(@Bono as money),'')

			DBCC checkident ('Rol', reseed)
		End
		Else
		Begin
 			Update Rol set Nombre=UPPER(@Nombre),BonoHora=Cast(@Bono as money),PagoEntregaPaq=Cast(@BonoPaq as bit)
			Where ID=@Id
		End
 End
 ---BUSCA  X Codigo
 if @Opc=2 
 Begin
	Select e.ID,e.Nombre,BonoHora,PagoEntregaPaq=case when PagoEntregaPaq=1 then 'SI'else 'NO' end,Situacion
	from Rol e with(nolock) 
	Where e.ID=@ID
 end
 ---BORRA 
 if @Opc=3 
 Begin
	Update Rol Set Situacion=Case
								When Situacion='B' then ''
								Else 'B'
								End
	Where ID=@Id
 end
---TODOS LOS REGISTROS 
 if @Opc=4 
 Begin
 	Select ID,Nombre,CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(BonoHora  AS MONEY), 1)) as BonoHora,
			PagoEntregaPaq=case when PagoEntregaPaq=1 then 'SI'else 'NO' end,
			Situacion=Case
							when Situacion='B' then 'Borrado'
							else ''
					end
	from Rol with(nolock)

 end

END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[c_spTipo]    Script Date: 11/01/2022 08:53:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[c_spTipo] 
	@Opc int,
	@Id int=null,
	@Nombre varchar(90)=NULL,
	@Vale varchar(15)=NULL,
	@Filtro varchar(100)=null
AS

set nocount on
SET DateFormat ymd

BEGIN TRY

--AGREGA UNO NUEVO O ACTUALIZA  
 if @Opc=1 
 Begin
		if  @id is null
		Begin
			set @id=0
		End

		if NOT EXISTS (select Nombre from Tipo with(nolock) where ID=@Id)
		Begin
			Insert Tipo(Nombre,ValeDespensa,Situacion)
			values(UPPER(@Nombre),Cast(@Vale as money),'')

			DBCC checkident ('Tipo', reseed)
		End
		Else
		Begin
 			Update Tipo set Nombre=UPPER(@Nombre),ValeDespensa=Cast(@Vale as money)
			Where ID=@Id
		End
 End
 ---BUSCA  X Codigo
 if @Opc=2 
 Begin
	Select e.ID,e.Nombre,ValeDespensa,Situacion
	from Tipo e with(nolock) 
	Where e.ID=@ID
 end
 ---BORRA 
 if @Opc=3 
 Begin
	Update Tipo Set Situacion=Case
								When Situacion='B' then ''
								Else 'B'
								End
	Where ID=@Id
 end
---TODOS LOS REGISTROS 
 if @Opc=4 
 Begin
 	Select ID,Nombre,CONVERT(VARCHAR, CONVERT(VARCHAR, CAST(ValeDespensa  AS MONEY), 1)) as ValeDespensa,
			Situacion=Case
							when Situacion='B' then 'Borrado'
							else ''
					end
	from Tipo with(nolock)

 end

END TRY
BEGIN CATCH
    INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());
END CATCH
GO
