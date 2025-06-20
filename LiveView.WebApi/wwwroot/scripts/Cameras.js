fetch('/api/cameras')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('cameraList');
        data.forEach(camera => {
            const li = document.createElement('li');
            li.innerHTML = `
                            <strong>${camera.cameraName}</strong>
                            <br><small>IP: ${camera.ipAddress || 'N/A'}</small>
                            <br><small>Server: ${camera.serverDisplayName}</small>
                            <br><small>Stream: ${camera.httpStreamUrl || 'N/A'}</small>
                            <hr>`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        document.getElementById('cameraList').innerHTML = '<li>Error occurred during loading cameras list.</li>';
        console.error('Fetch error:', error);
    });
