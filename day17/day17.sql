-- 1. print the storeid and number of orders for the store
select stor_id, count(*) as ord_num
from sales
group by stor_id;

-- 2. print the number of orders for every title
select title_id, count(*) as ord_num
from sales
group by title_id;

-- 3. print the publisher name and book name
select publishers.pub_name as "publisher name", titles.title as "book name"
from publishers
join titles on publishers.pub_id = titles.pub_id;

-- 4. print the author full name for all the authors
select au_fname + ' ' + au_lname as 'full name'
from authors;

-- 5. print the price of every book with tax
select title as "book name", (price + price * 12.36 / 100) as "price with tax"
from titles;

-- 6. print the author name and title name
select authors.au_fname + ' ' + authors.au_lname as 'author name', titles.title as 'title name'
from authors
join titleauthor on authors.au_id = titleauthor.au_id
join titles on titleauthor.title_id = titles.title_id;

-- 7. print the author name, title name, and the publisher name
select authors.au_fname, authors.au_lname, titles.title, publishers.pub_name
from authors
join titleauthor on authors.au_id = titleauthor.au_id
join titles on titleauthor.title_id = titles.title_id
join publishers on titles.pub_id = publishers.pub_id;

-- 8. print the average price of books published by every publisher
select publishers.pub_name, avg(titles.price) as "average price"
from titles
join publishers on titles.pub_id = publishers.pub_id
group by publishers.pub_name;

-- 9. print the books published by 'marjorie'
select titles.title
from titles
join titleauthor on titles.title_id = titleauthor.title_id
join authors on authors.au_id = titleauthor.au_id
where authors.au_fname = 'marjorie';

-- 10. print the order numbers of books published by 'new moon books'
select sales.ord_num as "order no of books published by new moon books"
from sales
join titles on sales.title_id = titles.title_id
join publishers on publishers.pub_id = titles.pub_id
where publishers.pub_name = 'new moon books';

-- 11. print the number of orders for every publisher
select publishers.pub_id, count(sales.ord_num) as "no of orders"
from sales
join titles on titles.title_id = sales.title_id
join publishers on publishers.pub_id = titles.pub_id
group by publishers.pub_id;

-- 12. print the order number, book name, quantity, price, and the total price for all orders
select sales.ord_num, titles.title, sales.qty, titles.price, sales.qty * titles.price as "total price"
from titles
join sales on titles.title_id = sales.title_id;

-- 13. print the total order quantity for every book
select titles.title_id, sum(sales.qty) as "order quantity"
from sales
join titles on titles.title_id = sales.title_id
group by titles.title_id;

-- 14. print the total order value for every book
select titles.title, sales.qty * titles.price as "total price"
from titles
join sales on titles.title_id = sales.title_id;

-- 15. print the orders that are for the books published by the publisher for which 'paolo' works
select sales.ord_num as "orders"
from sales
join titles on sales.title_id = titles.title_id
join publishers on publishers.pub_id = titles.pub_id
join employee on employee.pub_id = publishers.pub_id
where employee.fname = 'paolo';
