fetch('/api/templates')
    .then(response => response.json())
    .then(data => {
        const list = document.getElementById('templateList');
        data.forEach(template => {
            const li = document.createElement('li');
            li.innerHTML = `
                            <strong>${template.templateName}</strong>
                            <hr>`;
            list.appendChild(li);
        });
    })
    .catch(error => {
        document.getElementById('templateList').innerHTML = '<li>Error occurred during loading templates list.</li>';
        console.error('Fetch error:', error);
    });
