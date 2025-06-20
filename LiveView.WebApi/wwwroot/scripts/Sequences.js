fetch('/api/sequences')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('sequenceList');
        data.forEach(sequence => {
            const li = document.createElement('li');
            li.innerHTML = `
                            <strong>${sequence.name}</strong>
                            <br><small>Active: ${sequence.active}</small>
                            <br><small>Priority: ${sequence.priority || 'N/A'}</small>
                            <hr>`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        document.getElementById('sequenceList').innerHTML = '<li>Error occurred during loading sequences list.</li>';
        console.error('Fetch error:', error);
    });
