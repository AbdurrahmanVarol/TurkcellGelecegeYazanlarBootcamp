select CategoryName,count(*),AVG(UnitPrice) from Categories 
inner join Products on Categories.CategoryID = Products.CategoryID
group by Categories.CategoryName


select Customers.CompanyName,CONVERT(NVARCHAR,Orders.OrderDate,103),Orders.OrderID from Customers
join Orders on Customers.CustomerID = Orders.CustomerID
join [Order Details] on Orders.OrderID = [Order Details].OrderID

select 
	o.OrderID,
	c.CompanyName,
	o.OrderDate,
	e.FirstName + ' ' + e.LastName 'Çalışan',
	s.CompanyName 'Kargo',
	sup.CompanyName 'Tedatikçi',
	ca.CategoryName,
	p.ProductName,
	od.Quantity,
	od.UnitPrice * od.Quantity 'Ödenen'
from Orders o
join Customers c on o.CustomerID = c.CustomerID
join Employees e on o.EmployeeID = e.EmployeeID
join Shippers s on o.ShipVia = s.ShipperID
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
join Categories ca on p.CategoryID = ca.CategoryID
join Suppliers sup on p.SupplierID = sup.SupplierID


select c.CategoryName,p.ProductName from Categories c
left join Products p on c.CategoryID = p.CategoryID

SELECT
Calisanlar.FirstName + ' ' + Calisanlar.LastName 'ÇALIŞAN',
Mudurler.FirstName + ' ' + Mudurler.LastName 'MUDUR'
FROM Employees as Calisanlar 
LEFT JOIN Employees as Mudurler ON Calisanlar.ReportsTo = Mudurler.EmployeeID

select * from Orders  cross join [Order Details]


select ProductName from Products
where UnitPrice = (
select MAX(UnitPrice) from Products	
)


-- Hangi çalışan ne kadar satış yapmıştır
-- En fazla tercih edilen kargo şirketi
