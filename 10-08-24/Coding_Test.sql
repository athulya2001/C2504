#1

Find Employees Who Earn More Than Their Managers
Problem: Given an `Employees` table
with columns `EmployeeID`, `ManagerID`, and `Salary`,
find employees who earn more than their managers.

SELECT e.employeeID, e.salary, m.salary AS m_salary
From Employees AS e
INNER JOIN Employee AS m 
            ON e.employeeID = m.ManagerID
WHERE e.salary > m.salary


#2

Find the Top N Products by Sales Volume
Problem: Given a `Sales` table
with columns `ProductID`, `SaleAmount`, and `SaleDate`,
find the top 5 products by total sales volume.

Table Structure:
```
CREATE TABLE Sales (
ProductID INT,
SaleAmount DECIMAL(10, 2),
SaleDate DATE
);


SELECT ProductID, SUM(SaleAmount) AS Total_Sales
FROM Sales
GROUP BY
    ProductID
ORDER BY
   Total_Sales ASC;


#3

Find Total Sales per Month
Problem: Given a `Sales` table
with columns `SaleAmount` and `SaleDate`,
find the total sales amount for each month.

SELECT month(SaleDate) AS month,
            (SELECT sum(SaleAmount) AS Total_Sales
              FROM Sales s1
              WHERE month(s1.SalesDate) = month(s2.SalesDate))
From Sales s2
GROUP BY 
      month(SaleDate);


#4
  
Find the Total Number of Orders and Total Order Value by Customer
Problem: Given an `Orders` table,
find the total number of orders and
total order value for each customer.


CREATE TABLE Orders(
    Customer_id int primary key,
    Orderid int unique,
    OrdeValue int ,
);

SELECT 
       COUNT(OrderID) AS Total_Orders,
       SUM(OrderValue) AS Total_Order_Value,
       CustomerID 
FROM Orders
GROUP BY CustomerID;


#5

SELECT 
    (EmployeeID) AS Total_Employee,
     DepartmentID, 
     AVG(Salary) AS AVG_Salary
FROM 
   Employees
GROUP BY 
   DepartmentID;

