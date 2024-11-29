--1.      How many products can you find in the Production.Product table?
SELECT COUNT(p.ProductID) AS ProductCount
FROM Production.Product p

--2.      Write a query that retrieves the number of products in the Production.Product table that are included in a 
--subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(p.ProductID) AS SubcategoryCount
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL;

--3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.
--ProductSubcategoryID CountedProducts
SELECT p.ProductSubcategoryID, COUNT(p.ProductID) AS CountedProducts
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL
GROUP BY p.ProductSubcategoryID;

--4.      How many products that do not have a product subcategory.
SELECT COUNT(p.ProductID) AS ProductCount
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NULL;

--5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(p.Quantity)
FROM Production.ProductInventory p;

--6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and 
--limit the result to include just summarized quantities less than 100.
SELECT p.ProductID, SUM(p.Quantity) AS TheSum
FROM Production.ProductInventory p
WHERE p.LocationID = 40
GROUP BY p.ProductID
HAVING SUM(p.Quantity) < 100;

--7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and 
--LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT p.Shelf, p.ProductID, SUM(p.Quantity) AS TheSum
FROM Production.ProductInventory p
WHERE p.LocationID = 40
GROUP BY p.Shelf, p.ProductID
HAVING SUM(p.Quantity) < 100;

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table 
--Production.ProductInventory table.
SELECT AVG(p.Quantity) AS AvgQuantity
FROM Production.ProductInventory p
WHERE p.LocationID = 10;

--9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) AS AvgQuantity
FROM Production.ProductInventory p
GROUP BY p.ProductID, p.Shelf;

--10.  Write query  to see the average quantity  of  products by shelf excluding rows 
--that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT p.ProductID, p.Shelf, AVG(p.Quantity) AS AvgQuantity
FROM Production.ProductInventory p
WHERE p.Shelf != 'N/A'
GROUP BY p.ProductID, p.Shelf;

--11.  List the members (rows) and average list price in the Production.Product table. This should be grouped 
--independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT p.Color, p.Class, COUNT(p.Color) AS TheCount, AVG(p.ListPrice) AS AvgPrice
FROM Production.Product p
WHERE p.Color IS NOT NULL AND p.Class IS NOT NULL
GROUP BY p.Color, p.Class;

--12.   Write a query that lists the country and province names from person. CountryRegion and person. 
--StateProvince tables. Join them and produce a result set similar to the following.
SELECT c.Name AS Country, s.Name AS Province
FROM person.CountryRegion c
JOIN person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode;

--13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince 
--tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.Name AS Country, s.Name AS Province
FROM person.CountryRegion c
JOIN person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada');

--14.  List all Products that has been sold at least once in last 27 years.
SELECT 
	DISTINCT p.ProductID, p.ProductName
FROM 
	dbo.Products AS p 
	JOIN dbo.[Order Details] AS od 
	ON p.ProductID = od.ProductID 
	JOIN dbo.Orders AS o 
	ON o.OrderID = od.OrderID
WHERE
	o.OrderDate >= DATEADD(YEAR, -27, GETDATE());


--15.  List top 5 locations (Zip Code) where the products sold most.
SELECT t.ShipPostalCode
FROM (
	SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS TotalSold
	FROM dbo.Orders AS o JOIN dbo.[Order Details] AS od ON od.OrderID = o.OrderID
	WHERE o.ShipPostalCode IS NOT NULL
	GROUP BY o.ShipPostalCode
	ORDER BY TotalSold DESC
) AS t;

--16.  List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT t.ShipPostalCode
FROM (
	SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS TotalSold
	FROM dbo.Orders AS o JOIN dbo.[Order Details] AS od ON od.OrderID = o.OrderID
	WHERE o.ShipPostalCode IS NOT NULL AND o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
	GROUP BY o.ShipPostalCode
	ORDER BY TotalSold DESC
) AS t;
--17.   List all city names and number of customers in that city.     
SELECT c.City, COUNT(c.CustomerID) AS CustomerCount
FROM dbo.Customers c
WHERE c.City IS NOT NULL
GROUP BY c.City;

--18.  List city names which have more than 2 customers, and number of customers in that city
SELECT c.City, COUNT(c.CustomerID) AS CustomerCount
FROM dbo.Customers c
WHERE c.City IS NOT NULL
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2;

--19.  List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate >= CAST('1998-01-01' AS DATE);

--20.  List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName;

--21.  Display the names of all customers  along with the  count of products they bought
SELECT 
	c.ContactName, COUNT(od.ProductID) AS ProductCount
FROM 
	dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY 
	c.ContactName;


--22.  Display the customer ids who bought more than 100 Products with count of products.
SELECT 
	c.ContactName, COUNT(od.ProductID) AS ProductCount
FROM 
	dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY 
	c.ContactName
HAVING COUNT(od.ProductID) > 100;


--23.  List all of the possible ways that suppliers can ship their products. Display the results as below
WITH T1 AS (
	SELECT DISTINCT od.ProductID, o.ShipVia ShipID
	FROM dbo.[Order Details] od JOIN dbo.Orders o ON od.OrderID = o.OrderID
)


SELECT s.CompanyName AS [Supplier Company Name], sp.CompanyName AS [Shipping Company Name]
FROM T1 JOIN dbo.Products p 
	ON T1.ProductID = p.ProductID JOIN dbo.Suppliers s 
	ON s.SupplierID = p.SupplierID JOIN dbo.Shippers sp
	ON sp.ShipperID = T1.ShipID
ORDER BY [Supplier Company Name];

--    Supplier Company Name                Shipping Company Name

--    ---------------------------------            ----------------------------------

--24.  Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM dbo.Orders o JOIN dbo.[Order Details] od ON od.OrderID = o.OrderID JOIN dbo.Products p ON p.ProductID = od.ProductID;

--25.  Displays pairs of employees who have the same job title.
SELECT e1.EmployeeID, e1.FirstName + ' ' + e1.LastName AS Employee1, e2.EmployeeID, e2.FirstName + ' ' + e2.LastName AS Employee2
FROM dbo.Employees e1 JOIN dbo.Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID;

--26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT e2.EmployeeID, e2.FirstName + ' ' + e2.LastName AS Managers, COUNT(e1.ReportsTo) AS Subordinates
FROM dbo.Employees e1 JOIN dbo.Employees e2 ON e1.ReportsTo = e2.EmployeeID
GROUP BY e2.EmployeeID, e2.FirstName + ' ' + e2.LastName
HAVING COUNT(e1.ReportsTo) > 2;

--27.  Display the customers and suppliers by city. The results should have the following columns
--City Name Contact Name, Type (Customer or Supplier)

SELECT s.City, s.ContactName
FROM dbo.Suppliers s
UNION ALL
SELECT c.City, c.ContactName
FROM dbo.Customers c;