create database TracknTrace
go
use TracknTrace

create table PlannedOrder
(
	plnum int, -- ma san pham
	matnr int, -- ma san pham
	gsmng float, -- so luong
	plwrk varchar(4), --plant
	lgort nvarchar(100), -- Kho
	maktx nvarchar(100) -- ten san pham
)
go

create table PlannedOrderDetail
(
	plnum int , -- Planned order
	matnr int primary key, -- ma san pham con
	maktx nvarchar(100), -- ten san pham con
	erfmg float, -- So luong
	erfme varchar(10), -- don vi tinh
	plwrk varchar(4), -- plan
	lgpro varchar(100), -- kho
	charg varchar(10), -- so batch
	posnr int, -- so thu tu
	foreign key (plnum) references dbo.PlannedOrder(plnum)
)
go

create procedure usp_GetListPlannedOrder
as
begin
	Select * from PlannedOrder
end

alter procedure usp_AddPlannedOrder
(
	@plnum int, -- ma san pham
	@matnr varchar(10), -- ma san pham
	@gsmng float, -- so luong
	@plwrk nvarchar(50), --plant
	@lgort nvarchar(4), -- Kho
	@maktx nvarchar(100) -- ten san pham
)
as
begin
	insert into dbo.PlannedOrder values (@plnum, @matnr, @gsmng, @plwrk, @lgort, @maktx);
end
go

delete from PlannedOrderDetail

execute usp_AddPlannedOrder 1234, 'A2345245', 3, N'VSIP', N'FGSA', N'En-edt-C 50ML'

alter procedure usp_GetListPlannedOrderDetail
as
begin
	Select * from PlannedOrderDetail
end

create procedure	
(
	@plnum int,
	@matnr nvarchar(10),
	@maktx nvarchar(100),
	@erfmg float,
	@erfme char(10),
	@plwmk varchar(4),
	@lgpro varchar(4),
	@charg varchar(50),
	@posnr int
)
as
begin
	insert into dbo.PlannedOrderDetail values (@plnum, @matnr, @maktx, @erfmg, @erfme,@plwmk, @lgpro,@charg,@posnr)
end
go

execute usp_AddPlannedOrderDetail 1234, A111, N'cotton', 5000, 'KG', 'AGVE', 'Vsip', 'X411', 454534
execute usp_AddPlannedOrderDetail 1234, A121, N'iron', 3000, 'KG', 'AGVE', 'Vsip', 'X411', 454533
execute usp_AddPlannedOrderDetail 1234, A121, N'iron', 3000, 'KG', 'AGVE', 'Vsip', 'X411', 454533

select * from PlannedOrderDetail where plnum = 1234

select * from PlannedOrder where plnum = 1234
	
select * from PlannedOrderDetail where matnr = 'A111'

update dbo.PlannedOrderDetail set erfmg = 10 where matnr = 'A111' and charg = 'X411'



