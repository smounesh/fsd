fetch('https://dummyjson.com/quotes')
    .then(response => response.json())
    .then(data => {
        const quotesContainer = document.querySelector('.quotes-container');
        let currentPage = 1;
        let quotesPerPage = 5;

        function displayQuotes(quotes) {
            quotesContainer.innerHTML = '';
            quotes.forEach(quote => {
                const quoteCard = document.createElement('div');
                quoteCard.className = 'col-md-6 col-lg-4 mb-4 quote-card';
                quoteCard.innerHTML = `
                    <h2>${quote.quote}</h2>
                    <p>- ${quote.author}</p>
                `;
                quotesContainer.appendChild(quoteCard);
            });
        }

        function generateQuotes() {
            const pageQuotes = data.quotes.slice((currentPage - 1) * quotesPerPage, currentPage * quotesPerPage);
            displayQuotes(pageQuotes);
        }

        function sortQuotesAZ() {
            data.quotes.sort((a, b) => a.quote.localeCompare(b.quote));
            currentPage = 1; // Reset to first page
            generateQuotes();
        }

        function sortQuotesZA() {
            data.quotes.sort((a, b) => b.quote.localeCompare(a.quote));
            currentPage = 1; // Reset to first page
            generateQuotes();
        }

        document.querySelector('.prev').addEventListener('click', () => {
            if (currentPage > 1) {
                currentPage--;
                generateQuotes();
            }
        });

        document.querySelector('.next').addEventListener('click', () => {
            if (currentPage * quotesPerPage < data.quotes.length) {
                currentPage++;
                generateQuotes();
            }
        });

        document.getElementById('sort-az').addEventListener('click', sortQuotesAZ);
        document.getElementById('sort-za').addEventListener('click', sortQuotesZA);

        document.getElementById('searchForm').addEventListener('submit', function(event) {
            event.preventDefault();
            const searchText = document.getElementById('searchInput').value.toLowerCase();
            const filteredQuotes = data.quotes.filter(quote => quote.quote.toLowerCase().includes(searchText) || quote.author.toLowerCase().includes(searchText));
            displayQuotes(filteredQuotes);
        });

        // Initiate fetching and displaying of quotes immediately
        generateQuotes();
    });