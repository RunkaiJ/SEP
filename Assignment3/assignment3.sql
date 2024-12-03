--1.      List all cities that have both Employees and Customers.
SELECT DISTINCT c.City
FROM Customers c JOIN Employees e ON c.City = e.City;

--2.      List all cities that have Customers but no Employee.

--a.      Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (
	SELECT e.City
	FROM Employees e
);

--b.      Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;

--3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductID, p.ProductName, SUM(od.Quantity) AS TotalOrderQuantities
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName;

--4.      List all Customer Cities and total products ordered by that city.
SELECT c.City, COUNT(DISTINCT od.ProductID) AS TotalProducts
FROM Customers c LEFT JOIN Orders o 
ON o.CustomerID = c.CustomerID JOIN [Order Details] od 
ON od.OrderID = o.OrderID
GROUP BY c.City;

--5.      List all Customer Cities that have at least two customers.
SELECT c.City, COUNT(c.CustomerID) AS CustomerCount
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) >= 2;

--6.      List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City, COUNT(DISTINCT od.ProductID) AS CustomerCount
FROM Customers c JOIN  Orders o 
ON c.CustomerID = o.CustomerID JOIN [Order Details] od 
ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(od.ProductID) >= 2;

--7.      List all Customers who have ordered products, but have the ¡®ship city¡¯ on the 
--order different from their own customer cities.
SELECT DISTINCT c.CustomerID, c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity;

--8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5 p.ProductID, p.ProductName, AVG(p.UnitPrice) AS AvgPrice, t.City, MAX(t.OrderQuantities) AS MostQuantities
FROM Products p JOIN (
	SELECT  c.City, od.ProductID, SUM(od.Quantity) AS OrderQuantities
	FROM [Order Details] od JOIN Orders o ON od.OrderID = o.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
	GROUP BY c.City, od.ProductID
) AS t ON t.ProductID = p.ProductID
GROUP BY p.ProductID, p.ProductName, t.City
ORDER BY MostQuantities DESC;


--9.      List all cities that have never ordered something but we have employees there.

--a.      Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City IS NOT NULL AND e.City NOT IN (
	SELECT o.ShipCity
	FROM Orders o
);

--b.      Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e LEFT JOIN Orders o ON o.ShipCity = e.City
WHERE o.ShipCity IS NULL AND e.City IS NOT NULL;

--10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is,
--and also the city of most total quantity of products ordered from. (tip: join  sub-query)
-- Step 1: Find the city where the employee sold the most orders

WITH EmployeeOrderCount AS (
    SELECT e.City AS EmployeeCity, COUNT(o.OrderID) AS OrdersSold
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
),
CityProductQuantity AS (
    SELECT o.ShipCity, SUM(od.Quantity) AS TotalQuantityOrdered
    FROM Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
),
MaxValues AS (
    SELECT MAX(OrdersSold) AS MaxOrdersSold, MAX(TotalQuantityOrdered) AS MaxTotalQuantity
    FROM EmployeeOrderCount e
    JOIN CityProductQuantity p ON e.EmployeeCity = p.ShipCity
)
SELECT e.EmployeeCity AS City
FROM EmployeeOrderCount e
JOIN CityProductQuantity p ON e.EmployeeCity = p.ShipCity
JOIN MaxValues mv ON e.OrdersSold = mv.MaxOrdersSold AND p.TotalQuantityOrdered = mv.MaxTotalQuantity;


--11. How do you remove the duplicates record of a table?
--Answer: To remove duplicates, we can use DISTINCT or GROUP BY.