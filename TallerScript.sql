
--use master;
--drop database Taller
--go

CREATE DATABASE Taller
ON (

NAME='Taller',
FILENAME='D:\taller\Taller.mdf'

);

go	
USE Taller;
go

CREATE TABLE MECANICOS(
Ci int PRIMARY KEY not null,
Contraseña varchar(20) not null,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Sueldo int null,
Direccion varchar(50),
Especialidad varchar(20),
Ci_Sustituto int  
FOREIGN KEY(Ci_Sustituto) REFERENCES MECANICOS(Ci), 
Telefono int not null,
);


go

CREATE TABLE SUSTITUYE(
Ci_Titular int not null unique,
Ci_Sustituto int not null ,
PRIMARY KEY(Ci_Sustituto,Ci_Titular),
FOREIGN KEY(Ci_Sustituto) REFERENCES Mecanicos(Ci),
FOREIGN KEY(Ci_Titular) REFERENCES Mecanicos(Ci),
);

go

CREATE TABLE ADMINISTRATIVOS(
Ci int PRIMARY KEY not null,
Contraseña varchar(20) not null,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Sueldo int null,
Direccion varchar(50),
Nivel_De_Instruccion varchar(20),
Telefono int not null, 
);



GO
CREATE TABLE CLIENTES(
Ci int PRIMARY KEY not null,
Contraseña varchar(20) not null,
Ci_Adm int not null,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Direccion varchar(20) not null,

FOREIGN KEY(Ci_Adm) REFERENCES ADMINISTRATIVOS(Ci),
Telefono int not null,
Activo bit not null
);

go

create TABLE VEHICULOS(
Matricula varchar(10) PRIMARY KEY not null,
Marca varchar(20) not null,
Modelo varchar(20) not null,
Año int not null, 
);

go

create TABLE CLIENTE_VEHICULOS(
Matricula varchar(10) UNIQUE not null,
Ci_Cliente int not null,
FOREIGN KEY(Matricula) REFERENCES VEHICULOS(Matricula),
FOREIGN KEY(Ci_Cliente) REFERENCES CLIENTES(Ci),
);

go

CREATE TABLE SERVIC(
Numero int PRIMARY KEY not null IDENTITY,
Matricula_Auto varchar(10) not null,
Ci_Cliente int not null,
Ci_Adm int not null,
Fecha datetime not null,
Estado varchar(20) not null,
FOREIGN KEY(Matricula_Auto) REFERENCES VEHICULOS(Matricula),
FOREIGN KEY(Ci_Cliente) REFERENCES CLIENTES(Ci),
FOREIGN KEY(Ci_Adm) REFERENCES ADMINISTRATIVOS(Ci),
);

go

CREATE TABLE FOTOS(
Id int PRIMARY KEY identity not null,
Matricula_Auto varchar(10) not null,
Imagen varchar(50) not null,
FOREIGN KEY(Matricula_Auto) REFERENCES VEHICULOS(Matricula),
);

go

CREATE TABLE TRABAJOS(
Codigo int PRIMARY KEY not null ,
Descripcion varchar(50) not null,
Ci_Mecanico int not null,
FOREIGN KEY(Ci_Mecanico) REFERENCES MECANICOS(Ci),
);


go

CREATE TABLE SERVICE_TRABAJOS(
id int primary key identity not null,
Num_Servic int not null,
Codigo_Trabajo int not null,
FOREIGN KEY(Num_Servic) REFERENCES SERVIC(Numero),
FOREIGN KEY(Codigo_Trabajo) REFERENCES TRABAJOS(Codigo),
);

go

CREATE TABLE CUPONES(
Numero int PRIMARY KEY not null ,
Ci_Cliente int not null,
Fecha datetime not null,
valor decimal not null,
FOREIGN KEY(Ci_Cliente) REFERENCES CLIENTES(Ci),
);

go



insert into MECANICOS values(1111,'meca1','Fernando','rodriguez',13000,'dir 2323','chapa y pintura',1111,2345634)
insert into MECANICOS values(2222,'meca2','marcelo','fernandez',14000,'dir 2324','electronica',1111,2345233)
insert into MECANICOS values(3333,'meca3','roberto','lopez',13000,'dir 2333','mecanica',2222,5555634)
go
insert into SUSTITUYE values(1111,1111)
insert into SUSTITUYE values(2222,1111)
insert into SUSTITUYE values(3333,2222)
go
insert into ADMINISTRATIVOS values(111111,'admin1','Fernando','gonzalez',12000,'dir 5665','alto',122323645)
insert into ADMINISTRATIVOS values(222222,'admin2','werner','gomez',11000,'dir 2555','medio',232344)
insert into ADMINISTRATIVOS values(333333,'admin3','facundo','gonzalez',10000,'dir 2666','bajo',222564645)
go
insert into CLIENTES values(121212,'cli1',111111,'joaquin','olivo','dir 3666',422564645,0)
insert into CLIENTES values(131313,'cli2',222222,'carlos','vuillagran','dir 466',332564645,0)
insert into CLIENTES values(141414,'cli3',333333,'juan','olivarez','dir 3444',42334645,0)
insert into CLIENTES values(151515,'cli4',111111,'fede','martinez','dir 226',22264645,0)
insert into CLIENTES values(161616,'cli5',222222,'manuel','gil','dir 466',332564645,0)
insert into CLIENTES values(171717,'cli6',333333,'juan manuel','sosa','dir 3334',43434645,0)
go
insert into VEHICULOS values('fra 1212','ford','escort',1998)
insert into VEHICULOS values('sdx 3434','volkswagen','logus',2000)
insert into VEHICULOS values('frd 2323','marca3','modelo3',1998)
insert into VEHICULOS values('sfr 3444','marca4','modelo4',2000)
insert into VEHICULOS values('tcs 3433','marca5','modelo5',1998)
insert into VEHICULOS values('sdx 2334','marca6','modelo5',2000)
insert into VEHICULOS values('fra 5512','marca7','modelo8',1998)
insert into VEHICULOS values('sdx 3433','marca9','modelo9',2000)

go
insert into CLIENTE_VEHICULOS values('fra 1212',121212)
insert into CLIENTE_VEHICULOS values('sdx 3434',121212)
insert into CLIENTE_VEHICULOS values('frd 2323',131313)
insert into CLIENTE_VEHICULOS values('sfr 3444',141414)
insert into CLIENTE_VEHICULOS values('tcs 3433',151515)
insert into CLIENTE_VEHICULOS values('sdx 2334',161616)
insert into CLIENTE_VEHICULOS values('fra 5512',161616)
insert into CLIENTE_VEHICULOS values('sdx 3433',171717)
go
insert into SERVIC values('fra 1212',121212,111111,'1/1/08','TERMINADO')
insert into SERVIC values('sdx 3434',121212,111111,'1/1/08','PENDIENTE')
insert into SERVIC values('frd 2323',131313,222222,'1/1/09','TERMINADO')
insert into SERVIC values('sfr 3444',141414,333333,'1/1/09','PENDIENTE')
insert into SERVIC values('tcs 3433',151515,111111,'1/1/10','EN CURSO')
insert into SERVIC values('sdx 2334',161616,222222,'1/1/11','EN CURSO')
insert into SERVIC values('fra 5512',161616,222222,'1/1/11','PENDIENTE')
insert into SERVIC values('sdx 3433',171717,333333,'1/1/12','PENDIENTE')
go
insert into TRABAJOS values(1,'cambio de aceite',1111)
insert into TRABAJOS values(2,'pintura techo',1111)
insert into TRABAJOS values(3,'cambio de motor',1111)
insert into TRABAJOS values(4,'vidrios nuevos',1111)
insert into TRABAJOS values(5,'calibrar ruedas',1111)
insert into TRABAJOS values(6,'cambio de faroles delant',1111)
insert into TRABAJOS values(7,'pintura de puertas',1111)
insert into TRABAJOS values(8,'radiador nuevo',2222)
insert into TRABAJOS values(9,'cambio de agua',2222)
insert into TRABAJOS values(10,'cambio de llantas',2222)
insert into TRABAJOS values(11,'asientos nuevos',2222)
insert into TRABAJOS values(12,'paragolpe nuevo',2222)
insert into TRABAJOS values(13,'trabajo1',2222)
insert into TRABAJOS values(14,'trabajo2',3333)
insert into TRABAJOS values(15,'trabajo3',3333)
insert into TRABAJOS values(16,'trabajo4',3333)
insert into TRABAJOS values(17,'trabajo5',3333)
insert into TRABAJOS values(18,'trabajo6',3333)
insert into TRABAJOS values(19,'trabajo7',1111)
insert into TRABAJOS values(20,'trabajo8',1111)
insert into TRABAJOS values(21,'trabajo9',1111)
insert into TRABAJOS values(22,'trabajo10',1111)
go

insert into SERVICE_TRABAJOS values(1,1)
insert into SERVICE_TRABAJOS values(1,2)
insert into SERVICE_TRABAJOS values(1,3)
insert into SERVICE_TRABAJOS values(2,6)
insert into SERVICE_TRABAJOS values(2,4)
insert into SERVICE_TRABAJOS values(3,5)
insert into SERVICE_TRABAJOS values(4,7)
insert into SERVICE_TRABAJOS values(4,8)
insert into SERVICE_TRABAJOS values(4,9)
insert into SERVICE_TRABAJOS values(4,10)
insert into SERVICE_TRABAJOS values(5,11)
insert into SERVICE_TRABAJOS values(5,12)
insert into SERVICE_TRABAJOS values(5,13)
insert into SERVICE_TRABAJOS values(6,14)
insert into SERVICE_TRABAJOS values(6,15)
insert into SERVICE_TRABAJOS values(6,16)
insert into SERVICE_TRABAJOS values(7,17)
insert into SERVICE_TRABAJOS values(7,18)
insert into SERVICE_TRABAJOS values(8,19)
insert into SERVICE_TRABAJOS values(8,20)
insert into SERVICE_TRABAJOS values(8,21)
insert into SERVICE_TRABAJOS values(8,22)
go
insert into CUPONES values (1,121212,'1/5/08',2500)
insert into CUPONES values (2,121212,'1/5/09',2500)
insert into CUPONES values (3,121212,'1/5/09',2500)
insert into CUPONES values (4,131313,'1/5/08',2500)
insert into CUPONES values (5,131313,'1/5/08',2500)
insert into CUPONES values (6,151515,'1/5/10',2500)
insert into CUPONES values (7,151515,'1/5/11',2500)
insert into CUPONES values (8,171717,'1/5/12',2500)
insert into CUPONES values (9,171717,'1/5/09',2500)
insert into CUPONES values (10,171717,'1/5/07',2500)
insert into CUPONES values (11,171717,'1/5/08',2500)

go
--procedimientos

--*************************************************  FUNCIONARIOS *********************************************


--------------------------------------------------------------------------------------------------------
---------------------------------------------LOGUEO ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc LogueoAdministrativo @Cedula int,@Contraseña varchar(20)
as
begin
	if not exists(select * from ADMINISTRATIVOS where Ci=@Cedula and Contraseña=@Contraseña)
		begin
			return -2
		end
	else
		begin
			select * from ADMINISTRATIVOS where Ci=@Cedula and Contraseña=@Contraseña
		end
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------CALCULO SUELDO MECANICO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc CalculoSueldoMecanico @Fecha1 datetime,@Fecha2 datetime,@Ci_Mecanico int
as
Begin
	begin transaction --cantidad de dias trabajados
	 declare @Dias int
	 select @Dias=(COUNT(TRABAJOS.Codigo))
	 from MECANICOS inner join TRABAJOS inner join SERVICE_TRABAJOS inner join SERVIC
	 on SERVIC.Numero=SERVICE_TRABAJOS.Num_Servic
	 on SERVICE_TRABAJOS.Codigo_Trabajo=TRABAJOS.Codigo
	 on TRABAJOS.Ci_Mecanico=MECANICOS.Ci
	 and SERVIC.Fecha>@Fecha1 and SERVIC.Fecha<@Fecha2 
	 and Ci_Mecanico=@Ci_Mecanico 
	 if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	--producto de los dias trabajados por el jornal			
	Declare @Sueldo int
	select @Sueldo=@Dias*((MECANICOS.Sueldo/@Dias)+(MECANICOS.Sueldo*0.05)) from MECANICOS 
	where Ci=@Ci_Mecanico
	
	 if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	COMMIT TRANSACTION
	RETURN @Sueldo
end
go
--------------------------------------------------------------------------------------------------------
---------------------------------------------CALCULO SUELDO ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------

create proc CalculoSueldoAdministrativo @Fecha1 datetime,@Fecha2 datetime,@Ci_Admin int
as
Begin
		begin transaction
	 declare @Dias int
	 select @Dias=(COUNT(SERVIC.Ci_Adm))
	 from SERVIC inner join ADMINISTRATIVOS
	 on ADMINISTRATIVOS.Ci=SERVIC.Ci_Adm
	 and SERVIC.Fecha>@Fecha1 and SERVIC.Fecha<@Fecha2 
	 and Ci_Adm=@Ci_Admin 
	  if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
		declare @Sueldo int
		select @Sueldo=@Dias*(ADMINISTRATIVOS.Sueldo/@Dias)		
		from  ADMINISTRATIVOS
		Where Ci=@Ci_Admin 
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc AgregarAdministrativo @cedula int,@Contraseña varchar(20),@Nombre varchar(20),@Apellido varchar(20),@Sueldo int,@Direccion varchar(50),@NivelDeInstruccion varchar(20), @Telefono int
as
begin
	if not exists(select * from ADMINISTRATIVOS where Ci=@Cedula)
		begin
		insert into ADMINISTRATIVOS values(@cedula,@Contraseña,@Nombre,@apellido,@Sueldo,@Direccion,@NivelDeInstruccion,@Telefono)
		end
	else
		begin
		return -1
		end
end
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc EliminarAdministrativo @Cedula int
as
begin
	if not exists(select * from ADMINISTRATIVOS where Ci=@Cedula)
		begin
		return -1
		end
	else
		begin
		delete ADMINISTRATIVOS where Ci=@Cedula
		return -2
		end
end
go

--------------------------------------------------------------------------------------------------------
--------------------------------------COMPROBAR RELACION ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ComprobarRelacionAdministrativo @cedula int
as
begin
if not exists (select * from CLIENTES where Ci_Adm=@cedula)
	begin
		if not exists (select * from SERVIC where Ci_Adm=@cedula)
			return -1
		else
			return -2
	end
else 
	return -3
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc ModificarAdministrativo @Cedula int,@Contraseña varchar(20),@Nombre varchar(20),@Apellido varchar(20),@Sueldo int,@Direccion varchar(50),@NivelDeInstruccion varchar(20),@Telefono int
as
begin
	
	update ADMINISTRATIVOS set Contraseña=@Contraseña,Nombre=@Nombre,Apellido=@apellido,Sueldo=@Sueldo,Direccion=@Direccion,Nivel_De_Instruccion=@NivelDeInstruccion,Telefono=@Telefono
	where Ci=@Cedula
	RETURN -1
end

go

--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR ADMINISTRATIVO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc BuscarAdministrativo @Cedula int
as
Begin
	if not exists(select * from ADMINISTRATIVOS where Ci=@Cedula)
	return -1
	else
		Begin
			select * from ADMINISTRATIVOS where Ci=@Cedula
		End
end

go






--------------------------------------------------------------------------------------------------------
---------------------------------------------LOGUEO MECANICO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc LogueoMecanico @Cedula int,@Contraseña varchar(20)
as
begin
	if not exists(select * from MECANICOS where Ci=@Cedula and Contraseña=@Contraseña)
		begin
			return -2
		end
	else
		begin
			select * from MECANICOS where Ci=@Cedula and Contraseña=@Contraseña
		end
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR MECANICO-------------------------------------------
--------------------------------------------------------------------------------------------------------
Create proc AgregarMecanico @cedula int,@Contraseña varchar(20),@Nombre varchar(20),@Apellido varchar(20),@Sueldo int,@Direccion varchar(50),@Especialidad varchar(20),@CedulaSustituto int,@Telefono int
as
begin
  if not exists(select * from MECANICOS where Ci=@Cedula)
	begin
		begin transaction
			insert into MECANICOS values(@Cedula,@Contraseña,@Nombre,@Apellido,@Sueldo,@Direccion,@Especialidad,@CedulaSustituto,@Telefono)
			if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
			insert into SUSTITUYE values(@Cedula,@CedulaSustituto)
			if @@ERROR<>0
				begin
						rollback transaction
						return -2
				end
		commit transaction
		return -3
	

		end
 else
	begin
		return -4 
    end
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR MECANICO-------------------------------------------
--------------------------------------------------------------------------------------------------------
Create proc EliminarMecanico @Cedula int
as
begin
	if not exists(select * from MECANICOS where Ci=@Cedula)
		begin
		return -1	
		end
		
	else
		begin
			begin transaction
			delete from SUSTITUYE where Ci_Titular=@Cedula
			if @@ERROR<>0
				begin
					rollback transaction
					return -2
				end
			delete from MECANICOS where Ci=@Cedula
			if @@ERROR<>0
				begin
					rollback transaction
					return -3
				end
				commit transaction
				return -4
			end
		end
	

go


--------------------------------------------------------------------------------------------------------
---------------------------------------------COMPROBAR RELACION MECANICO-------------------------------------------
--------------------------------------------------------------------------------------------------------
create proc ComprobarRelacionMecanico @Cedula int
as
begin
    if not exists(select * from SUSTITUYE where Ci_Sustituto=@Cedula)
		begin
			if not exists(select * from TRABAJOS where Ci_Mecanico=@Cedula)
			return -1
			else
			return -3
		end
	else
		return -2
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR MECANICO-------------------------------------------
--------------------------------------------------------------------------------------------------------
create proc ModificarMecanico @cedula int,@Contraseña varchar(20),@Nombre varchar(20),@Apellido varchar(20),@Sueldo int,@Direccion varchar(50),@Especialidad varchar(20),@CedulaSustituto int,@Telefono int
as
begin
  if not exists(select * from MECANICOS where Ci=@Cedula)
	begin
		begin transaction
			update SUSTITUYE set Ci_Titular=@Cedula,Ci_Sustituto=@CedulaSustituto
			where Ci_Titular=@cedula
			if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
			
			update MECANICOS set Contraseña=@Contraseña,Nombre=@Nombre,Apellido=@Apellido,Sueldo=@Sueldo,Direccion=@Direccion,Especialidad=@Especialidad,Telefono=@Telefono
			where Ci=@cedula
			if @@ERROR<>0
				begin
						rollback transaction
						return -2
				end
		commit transaction
		return -3
	

		end
 else
	begin
		return -4 
    end
end
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR MECANICO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc BuscarMecanico @Cedula int
as
Begin
	if not exists(select * from MECANICOS where Ci=@Cedula)
	return -1
	else
		Begin
		
			select * from MECANICOS where Ci=@Cedula
		
		End
end

go


--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR MECANICOS--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc ListarMecanicos
as
Begin
	select * from MECANICOS
end

go




--*************************  TRABAJOS  ***********************************



--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR TRABAJO--------------------------------------------
--------------------------------------------------------------------------------------------------------

Create proc AgregarTrabajo @Codigo int,@Descripcion varchar(50),@Ci_Mecanico int
as
Begin
	if not exists(select * from TRABAJOS where Codigo=@Codigo)
		begin
			insert into TRABAJOS values(@Codigo,@Descripcion,@Ci_Mecanico)
		end
	else
		begin
		return -1
		end
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR TRABAJO--------------------------------------------
--------------------------------------------------------------------------------------------------------

Create proc EliminarTrabajo @Codigo int
as
begin
 if not exists(select * from TRABAJOS where Codigo=@Codigo)
	begin
		return -1
	end
else
	begin
		delete from TRABAJOS where Codigo=@Codigo
	end
end
go

----------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR TRABAJO--------------------------------------------
---------------------------------------------------------------------------------------------------------

create proc ModificarTrabajo @Codigo int,@Descripcion varchar(50),@Ci_Mecanico int
as
Begin
	if not exists(select * from TRABAJOS where Codigo=@Codigo)
		begin
			return -1
		end
	else
		begin
			update TRABAJOS set Descripcion=@Descripcion,Ci_Mecanico=@Ci_Mecanico
			where Codigo=@Codigo
		end
end

go

create proc ListarTrabajosDisponibles
as
begin
	select * from TRABAJOS 
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR TRABAJO--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc BuscarTrabajo @Codigo int
as
Begin
	if not exists(select * from TRABAJOS where Codigo=@Codigo)
	return -1
	else
		Begin
			select * from TRABAJOS where Codigo=@Codigo
		End
end

go

--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR TRABAJO POR SERVICIO--------------------------------------
--------------------------------------------------------------------------------------------------------
go
create proc BuscarTrabajosPorServicio @NumServicio int
as 
		select t.* from ((SERVIC as s inner join SERVICE_TRABAJOS as z on s.Numero=z.Num_Servic)
						inner join TRABAJOS as t on z.Codigo_Trabajo=t.Codigo and s.Numero=@NumServicio) 
go
--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR TRABAJOS POR RANGO DE FECHAS--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc BuscarTrabajosPorRangoDeFechas @Fecha1 datetime,@Fecha2 datetime,@CiMecanico int
as
Begin
	 select Codigo_Trabajo,Descripcion,Ci_Mecanico from TRABAJOS inner join SERVICE_TRABAJOS inner join SERVIC
	 on SERVIC.Numero=SERVICE_TRABAJOS.Num_Servic
	 on SERVICE_TRABAJOS.Codigo_Trabajo=TRABAJOS.Codigo
	 and SERVIC.Fecha>@Fecha1 and SERVIC.Fecha<@Fecha2 and Estado='Entrada'
	 and Ci_Mecanico=@CiMecanico

end

go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR SERVICES Y TRABAJOS POR RANGO DE FECHAS--------------------------------------
--------------------------------------------------------------------------------------------------------
create proc ListarServicesYTrabajosPorRangoDeFechas @Fecha1 datetime,@Fecha2 datetime,@CiCliente int
as
Begin
	 select c.Ci,s.*,Descripcion from ((CLIENTES as c inner join SERVIC as s on c.Ci=s.Ci_Cliente) inner join SERVICE_TRABAJOS as z on s.Numero = z.Num_Servic) 
inner join TRABAJOS as t on z.Codigo_Trabajo = t.Codigo and s.Fecha>@Fecha1 and s.Fecha<@Fecha2 and c.Ci=@CiCliente
end

	
go	 


--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR CLIENTE---------------------------------------------
--------------------------------------------------------------------------------------------------------


create proc AgregarCliente @Ci int,@contraseña varchar(20), @CiAdm int, @Nombre varchar(20), @Apellido varchar(20),
@Direccion varchar(20),@tel1 int
as
	if not exists(select * from CLIENTES where Ci = @Ci)
		begin
		insert into CLIENTES values(@Ci,@contraseña,@CiAdm,@Nombre,@Apellido,@Direccion,@tel1,0)
				return -3
		end
	else
		begin
			return -4		
		end		
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR CLIENTE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc EliminarCliente @Ci int
as
	if not exists(select * from CLIENTES where @Ci = Ci)
		return -6
		else if exists (select * from SERVIC as s where Ci_Cliente = @Ci and s.Estado = 'En Curso')
			return -5
	else
	update CLIENTES
	set activo = 1	where CLIENTES.Ci = @Ci
			return 1
go	


--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR CLIENTE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ModificarCliente @Ci int,@contraseña varchar(20),@Nombre varchar(20), @Apellido varchar(20),
@Direccion varchar(20),@tel1 int
as
	if not exists(select * from CLIENTES where Ci = @Ci)
			return -4
	else		
		begin
		
				update CLIENTES 
				set Contraseña = @contraseña,
				Nombre =@Nombre ,
				Apellido = @Apellido,
				Direccion = @Direccion,
				Telefono=@tel1
				where Ci = @Ci
				return 1
	
			end
go	

--------------------------------------------------------------------------------------------------------
---------------------------------------------lOGUEO CLIENTE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc LogueoCLiente @cedula int,@contraseña varchar(20) 
as
begin
		select * from CLIENTES where Ci=@cedula and Contraseña=@contraseña
		
end
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR CLIENTE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc BuscarCLiente @cedula int 
as
begin
		select * from CLIENTES where Ci=@cedula and activo = 0	
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR CLIENTES---------------------------------------------
--------------------------------------------------------------------------------------------------------
create proc listarCLientes  
as
begin
 select * from CLIENTES where activo = 0
		
end
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR VEHICULO---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc AgregarVehiculo @Matricula varchar(10),@Marca varchar(20),@Modelo varchar(20),
@Ano int,@Ci_Cliente int
as
	if exists (select * from VEHICULOS where Matricula = @Matricula)
		return -4
	else
		begin
			begin transaction
			insert into VEHICULOS values(@Matricula,@Marca,@Modelo,@Ano)
			if @@ERROR<>0
				begin
					rollback transaction
						return -3
				end		
				
			insert into CLIENTE_VEHICULOS values(@Matricula,@Ci_Cliente)
			if @@ERROR<>0
				begin
					rollback transaction
						return -2
				end
				
				commit transaction
				return 1
		end

go		

--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR VEHICULO---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc EliminarVehiculo @matricula varchar(10)
as
	if not exists(select * from VEHICULOS where @matricula = Matricula)
		return -4
		
	else
		begin
			begin transaction
			
			delete from FOTOS where Matricula_Auto=@matricula
				if @@ERROR<>0
						begin
							rollback transaction
							return -3
						end	 
						
			delete from CLIENTE_VEHICULOS where Matricula=@matricula
				if @@ERROR<>0
						begin
							rollback transaction
							return -1
						end
			
			
				delete from VEHICULOS where @matricula = Matricula
					if @@ERROR<>0
						begin
							rollback transaction
							return -2
						end	
			
						
					
						commit transaction
						return 1
			end			
go
--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR VEHICULO---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ModificarVehiculo @Matricula varchar(10),@Marca varchar(20),@Modelo varchar(20),@Ano int
as
	if not exists(select * from VEHICULOS where Matricula = @Matricula)
		return -4
	else
		begin
			
		update VEHICULOS set Marca = @Marca,Modelo = @Modelo, Año = @Ano 
		where @Matricula = Matricula
			
	
			end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR VEHICULOS---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ListarVehiculos @cedula int
as
begin
	select * from VEHICULOS inner join CLIENTE_VEHICULOS
	on CLIENTE_VEHICULOS.Matricula=VEHICULOS.Matricula
	and CLIENTE_VEHICULOS.Ci_Cliente=@cedula
end 
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR VEHICULOS 2 SIN CEDULA---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ListarVehiculos2 
as
begin
	select * from VEHICULOS
end 
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR VEHICULO---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc BuscarVehiculo @matricula varchar(10)
as
begin
	select * from VEHICULOS where Matricula=@matricula
	end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR FOTO---------------------------------------------
--------------------------------------------------------------------------------------------------------
create PROC AgregarFoto @Matricula varchar(50),@Imagen varchar(50)
as
begin
declare @id int
	begin transaction

		
		insert into FOTOS values(@Matricula,@Imagen)
		if @@ERROR<>0
		begin
		rollback transaction
		return -1
		end

		select @id=Id from FOTOS where Matricula_Auto=@Matricula and Imagen=@Imagen
		if @@ERROR<>0
		begin
		rollback transaction
		return -1
		end
		
		commit transaction
		return @id
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------ELIMINAR FOTO---------------------------------------------
--------------------------------------------------------------------------------------------------------
create PROC EliminarFoto @Id int
as
begin
delete from FOTOS where Id=@Id
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR FOTO---------------------------------------------
--------------------------------------------------------------------------------------------------------
create PROC ModificarFoto @Id int,@dir varchar(50)
as
begin
update FOTOS set Imagen=@dir where Id=@Id
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR FOTOS---------------------------------------------
--------------------------------------------------------------------------------------------------------
CREATE PROC Listarfotos @matricula varchar(10)
as
begin
select * from FOTOS where Matricula_Auto=@matricula
end
go

--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR VEHICULOS Y FOTOS---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ListarVehiculosYFotos @matricula varchar(4)-- nuevoooooooooooooooooooooooooooooooooooo
as
	select * from VEHICULOS as v inner join FOTOS as f on v.Matricula=f.Matricula_Auto
	where v.Matricula= @matricula
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------AGREGAR SERVICE---------------------------------------------
--------------------------------------------------------------------------------------------------------


create proc AgregarServicio @Matricula varchar(10),@ci_cliente int,@ci_adm int,
@fecha datetime,@estado varchar(20),@codtrabajo int
as
begin
	begin transaction
		insert into SERVIC values(@Matricula,@ci_cliente,@ci_adm,@fecha,@estado)
		declare @numero int
			if @@ERROR<>0
				begin
					rollback transaction
					return -4
				end
				set @numero = @@IDENTITY
		insert into SERVICE_TRABAJOS values(@numero,@codtrabajo)	--modificadooooooooooooooooooooooooooooooooooooooooo
			if @@ERROR<>0
					begin
						rollback transaction
						return -3
					end		
		commit transaction
			return 1
	end	
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------BUSCAR SERVICE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc BuscarServicio @numero int -- nuevooooooooooooooooooooooooooooooooooooooo
as
	select * from SERVIC where SERVIC.Numero = @numero
go

create proc EliminarServicio @numero int -- modificadoooooooooooooooooooooooooooooooooooo
as
begin
if exists(select * from SERVIC as s where Estado='En Curso' and s.Numero=@numero)
	return -1
	else
	begin
	begin transaction
		delete SERVIC where Numero = @numero
			if @@ERROR<>0
				begin
					rollback transaction
					return -4
				end
		
			return 1
	end	
	end
go


--------------------------------------------------------------------------------------------------------
---------------------------------------------MODIFICAR SERVICE---------------------------------------------
--------------------------------------------------------------------------------------------------------

create proc ModificarServicio @numero int,@Matricula varchar(4),@ci_cliente int,@ci_adm int,
@fecha datetime,@estado varchar(20),@codtrabajo int
as
begin
	begin transaction
		update SERVIC 
		set Matricula_Auto =  @Matricula,
		Ci_Cliente = @ci_cliente,
		Ci_Adm = @ci_adm,
		Fecha = @fecha,
		Estado = @estado
			if @@ERROR<>0
				begin
					rollback transaction
					return -4
				end
		update SERVICE_TRABAJOS
		set Codigo_Trabajo =@codtrabajo	
			if @@ERROR<>0
					begin
						rollback transaction
						return -3
					end		
		commit transaction
			return 1
	end	
go

	
--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR SERVICES EN CURSO-----------------------------------
--------------------------------------------------------------------------------------------------------
create proc ListarServicesEnCurso @Ci_Cliente int
as
begin
Select * from SERVIC where Ci_Cliente=@Ci_Cliente
end

go
--------------------------------------------------------------------------------------------------------
---------------------------------------------LISTAR SERVICES EN CURSO-----------------------------------
--------------------------------------------------------------------------------------------------------
create proc ListarTrabajosDeService @Num int
as
begin
Select * from TRABAJOS inner join SERVICE_TRABAJOS inner join SERVIC
on SERVIC.Numero=SERVICE_TRABAJOS.Num_Servic
on SERVICE_TRABAJOS.Codigo_Trabajo=TRABAJOS.Codigo
and Num_Servic=@Num
end

go		
---------------------------------------------------------------------------------------------------
---------------------------------------------Buscar Cupon------------------------------------------
---------------------------------------------------------------------------------------------------

Create proc BuscarCupon @numero int
as
begin
if not exists(select * from CUPONES where Numero=@numero)
	return 1
	else
	 begin
		select * from CUPONES where Numero=@numero
	 end
end

go

---------------------------------------------------------------------------------------------------
---------------------------------------------Agregar Cupon------------------------------------------
---------------------------------------------------------------------------------------------------

create proc AgregarCupon @Numero int, @Fecha datetime, @Valor int, @Ci_Cliente int
as
begin
	if not exists(select * from CUPONES where Numero=@Numero) 
	   insert into CUPONES values (@Numero,@Ci_Cliente,@Fecha,@Valor) 
	   
	else
	   return 1
end

go

---------------------------------------------------------------------------------------------------
---------------------------------------------Eliminar Cupon------------------------------------------
---------------------------------------------------------------------------------------------------
create proc EliminarCupon @Numero int
as
begin
  if not exists (select * from CUPONES where Numero=@Numero)
  return 1
  else 
	delete from CUPONES where Numero=@Numero
end

go

---------------------------------------------------------------------------------------------------
---------------------------------------------Modificar Cupon------------------------------------------
---------------------------------------------------------------------------------------------------
create proc ModificarCupon @Numero int,@Fecha datetime,@Valor int,@Ci_Cliente int
as
begin
  if not exists (select * from CUPONES where Numero=@Numero)
    return 1
  else 
	update CUPONES set valor=@Valor,Fecha=@Fecha,Ci_Cliente=@Ci_Cliente where Numero=@Numero
end

go


