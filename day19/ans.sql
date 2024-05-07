-- 1) Create a stored procedure that will take the author's firstname and print all the books published by him with the publisher's name

CREATE PROCEDURE GetBooksByAuthor
    @AuthorFirstName NVARCHAR(50)
AS
BEGIN
    SELECT 
        t.title AS TitleName,
        p.pub_name AS PublisherName
    FROM 
        titles t
    JOIN 
        titleauthor ta ON t.title_id = ta.title_id
    JOIN 
        authors a ON ta.au_id = a.au_id
    JOIN 
        publishers p ON t.pub_id = p.pub_id
    WHERE 
        a.au_fname = @AuthorFirstName;
END

EXEC GetBooksByAuthor Johnson

-- 2) Create a stored procedure that will take the employee's firstname and print all the titles sold by him/her, price, quantity, and the cost


CREATE PROCEDURE GetTitleSoldByEmployee
    @EmployeeFirstName NVARCHAR(50)
AS
BEGIN
    SELECT
        t.title AS TitleName,
        t.price AS Price,
        s.qty AS Quantity,
        (t.price * s.qty) AS Cost
    FROM
        sales s
    JOIN
        titles t ON s.title_id = t.title_id
    JOIN
        employee e ON s.stor_id = e.emp_id
    WHERE
        e.fname = @EmployeeFirstName
END


EXEC GetTitleSoldByEmployee Paolo;

-- 3) Create a query that will print all names from authors and employees

SELECT 
    au_fname, 
    au_lname 
FROM 
    authors
UNION
SELECT 
    fname,
    lname
FROM 
    employee;

-- 4) Create a query that will fetch data from sales, titles, publisher, and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders, and print the first 5 orders after sorting them based on the price of the order

SELECT TOP 5
    t.title AS TitleName,
    p.pub_name AS PublisherName,
    CONCAT(a.au_fname, ' ', a.au_lname) AS AuthorFullName,
    s.qty AS QuantityOrdered,
    t.price AS OrderPrice
FROM 
    sales s
JOIN 
    titles t ON s.title_id = t.title_id
JOIN 
    publishers p ON t.pub_id = p.pub_id
JOIN 
    titleauthor ta ON t.title_id = ta.title_id
JOIN 
    authors a ON ta.au_id = a.au_id
ORDER BY 
    t.price;


-- 5) Grant SELECT permission on the Titles table to user1

CREATE LOGIN miles WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';  
GO

use pubs;

GRANT SELECT ON authors TO miles;
GO

-- Revoke SELECT permission on the Titles table from user1
REVOKE SELECT ON authors FROM miles;
GO


