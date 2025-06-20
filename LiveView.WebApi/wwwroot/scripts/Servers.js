fetch('/api/servers')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('serverList');
        data.forEach(server => {
            const li = document.createElement('li');
            li.innerHTML = `
                            <strong>${server.hostname} (${server.ipAddress})</strong>
                            <br><small>Credentials: ${server.username || 'N/A'} ${server.password || 'N/A'}</small>
                            <br><small>Windows Credentials: ${server.winUser || 'N/A'} ${server.winPass || 'N/A'}</small>
                            <hr>`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        document.getElementById('serverList').innerHTML = '<li>Error occurred during loading servers list.</li>';
        console.error('Fetch error:', error);
    });
