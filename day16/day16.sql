use pubs;

-- 1. Print all the titles names
SELECT title FROM titles;

-- 2. Print all the titles that have been published by 1389
SELECT title FROM titles WHERE pub_id = '1389';

-- 3. Print the books that have a price in the range of 10 to 15
SELECT title FROM titles WHERE price BETWEEN 10 AND 15;

-- 4. Print those books that have no price
SELECT title FROM titles WHERE price IS NULL;

-- 5. Print the book names that start with 'The'
SELECT title FROM titles WHERE title LIKE 'The%';

-- 6. Print the book names that do not have 'v' in their name
SELECT title FROM titles WHERE title NOT LIKE '%v%';

-- 7. Print the books sorted by royalty
SELECT title, royalty FROM titles ORDER BY royalty;

-- 8. Print the books sorted by publisher in descending order, then by types in ascending order, then by price in descending order
SELECT title, pub_id, type, price FROM titles ORDER BY pub_id DESC, type ASC, price DESC;

-- 9. Print the average price of books in every type
SELECT type, AVG(price) AS avg_price FROM titles GROUP BY type;

-- 10. Print all the types in unique
SELECT DISTINCT type FROM titles;

-- 11. Print the first 2 costliest books
SELECT TOP 2 title, price FROM titles ORDER BY price DESC;

-- 12. Print books that are of type business, have a price less than 20, and have an advance greater than 7000
SELECT title FROM titles WHERE type = 'business' AND price < 20 AND advance > 7000;

-- 13. Select those publisher IDs and the number of books which have a price between 15 to 25 and have 'It' in their name, printing only those with a count greater than 2, sorted in ascending order of count
SELECT pub_id, COUNT(*) AS book_count FROM titles WHERE price BETWEEN 15 AND 25 AND title LIKE '%It%' GROUP BY pub_id HAVING COUNT(*) > 2 ORDER BY book_count ASC;

-- 14. Print the authors who are from 'CA'
SELECT au_fname, au_lname FROM authors WHERE state = 'CA';

-- 15. Print the count of authors from every state
SELECT state, COUNT(*) AS author_count FROM authors GROUP BY state;
