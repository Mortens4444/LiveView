fetch('/api/grids')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('gridList');
        data.forEach(grid => {
            const li = document.createElement('li');
            li.innerHTML = `
                            <strong>${grid.name}</strong>
                            <br><small>Rows: ${grid.rows}</small>
                            <br><small>Columns: ${grid.columns}</small>
                            <br><small>Priority: ${grid.priority || 'N/A'}</small>
                            <hr>`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        document.getElementById('gridList').innerHTML = '<li>Error occurred during loading grids list.</li>';
        console.error('Fetch error:', error);
    });
