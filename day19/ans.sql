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

create proc GetBooksDetailsByEmployee
@firstname varchar(20)
as begin
select title, price, qty, (qty * price) as cost
from titles t
join sales s on s.title_id = t.title_id
join employee e on e.pub_id = t.pub_id
where fname = @firstname
end

EXEC GetBooksDetailsByEmployee Paolo;

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

select top 5 title, pub_name, concat(a.au_fname,' ', a.au_lname) as [Author Name], qty, (qty * price) as cost from titles t
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on ta.title_id = t.title_id
join authors a on a.au_id = ta.au_id
join sales s on s.title_id = t.title_id
order by cost


-- 5) Grant SELECT permission on the Titles table to user1

CREATE LOGIN miles WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';  
GO

use pubs;

GRANT SELECT ON authors TO miles;
GO

-- Revoke SELECT permission on the Titles table from user1
REVOKE SELECT ON authors FROM miles;
GO


