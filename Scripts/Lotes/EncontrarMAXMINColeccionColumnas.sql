use Doblones20
select * from VentasProductos
select * from VentasProductosDetalle

select CodigoProducto, PrecioUnitarioVenta1, PrecioUnitarioVenta2, PrecioUnitarioVenta3, PrecioUnitarioVenta4, PrecioUnitarioVenta5, PrecioUnitarioVenta6 from InventariosProductos




print 'Create table to hold test data'
create table #t (
	number int not null primary key clustered,
	Val1 int,
	Val2 int,
	Val3 int,
	Val4 int
)
GO
print 'Load test data'
insert into #t
select
	number,
	-- Generate random numbers
	-- with about 1/7th null
	case
	when abs(checksum(newid()))%7 = 0
	then null 
	else checksum(newid())%1000000
	end, 
	case
	when abs(checksum(newid()))%7 = 0
	then null 
	else checksum(newid())%1000000
	end, 
	case
	when abs(checksum(newid()))%7 = 0
	then null 
	else checksum(newid())%1000000
	end, 
	case
	when abs(checksum(newid()))%7 = 0
	then null 
	else checksum(newid())%1000000
	end
from
	-- Load one million rows of test data.
	-- Number table function here
	-- http://www.sqlteam.com/forums/topic.asp?TOPIC_ID=47685
	dbo.F_TABLE_NUMBER_RANGE(1,1000000)
go

select * from  #t

print 'Find rows that do not match for Method 1 and Method 2'
select
	out1.*--,
	--out2.*
from
(
-- Method 1, using a subquery with a max
select
	a.number,
 	a.Val1,
 	a.Val2,
 	a.Val3,
 	a.Val4,
 	[Max_of_Val1_to_Val4] =     
	  	(
	  	select
	   		X1= max(bb.xx)
	  	from
	   		(
	   		select xx = a.Val1 where a.Val1 is not null union all
	   		select xx = a.Val2 where a.Val2 is not null union all
	   		select xx = a.Val3 where a.Val3 is not null union all
	   		select xx = a.Val4 where a.Val4 is not null
	   		) bb
	  	)

from
 	#t a
) out1
join
(
-- Method 2, using a case
select
	a.number,
 	a.Val1,
 	a.Val2,
 	a.Val3,
 	a.Val4,
   	[Max_of_Val1_to_Val4] =  
	 	case
	 	when  a.Val1 is not null   and
	  		(a.Val1 >= a.Val2 or a.Val2 is null) and
	  		(a.Val1 >= a.Val3 or a.Val3 is null) and
	  		(a.Val1 >= a.Val4 or a.Val4 is null)
	 	then 	a.Val1
	 	when  	a.Val2 is not null   and
	  		(a.Val2 >= a.Val1 or a.Val1 is null) and
	  		(a.Val2 >= a.Val3 or a.Val3 is null) and
	  		(a.Val2 >= a.Val4 or a.Val4 is null)
	 	then 	a.Val2
	 	when  	a.Val3 is not null   and
	  		(a.Val3 >= a.Val1 or a.Val1 is null) and
	  		(a.Val3 >= a.Val2 or a.Val2 is null) and
	  		(a.Val3 >= a.Val4 or a.Val4 is null)
	 	then 	a.Val3
	 	when  	a.Val4 is not null   and
	  		(a.Val4 >= a.Val1 or a.Val1 is null) and
	  		(a.Val4 >= a.Val2 or a.Val2 is null) and
	  		(a.Val4 >= a.Val3 or a.Val3 is null)
	 	then a.Val4
	 	else null
	 	end
from
 	#t a
) out2
on out1.number = out2.number
where
	-- Look for results that do not match
	(out1.[Max_of_Val1_to_Val4] is null and  out2.[Max_of_Val1_to_Val4] is not null) or
	(out1.[Max_of_Val1_to_Val4] is not null and out2.[Max_of_Val1_to_Val4] is null) or
	out1.[Max_of_Val1_to_Val4] <> out2.[Max_of_Val1_to_Val4]
go
print 'Find count of rows with different columns null'
print 'Should have a rowcount of 16 to test all conditions'
select
	Null_Column_Conditions =
	case when Val1 is null then 0 else 1000 end+ 
	case when Val2 is null then 0 else 0100 end+ 
	case when Val3 is null then 0 else 0010 end+ 
	case when Val4 is null then 0 else 0001 end,
	count(*)
from
	#t
group by
	case when Val1 is null then 0 else 1000 end+ 
	case when Val2 is null then 0 else 0100 end+ 
	case when Val3 is null then 0 else 0010 end+ 
	case when Val4 is null then 0 else 0001 end
order by
	1
go
drop table #t

