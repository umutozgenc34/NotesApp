const apiUrl = 'http://localhost:5055/api/Notes';


const notesContainer = document.getElementById('notes');
const noteForm = document.getElementById('noteForm');
const noteId = document.getElementById('noteId');
const noteTitle = document.getElementById('noteTitle');
const noteContent = document.getElementById('noteContent');


async function fetchNotes() {
    const response = await fetch(apiUrl);
    const notes = await response.json();
    notesContainer.innerHTML = notes.map(note => `
        <div class="note">
            <h3>${note.title}</h3>
            <p>${note.content}</p>
            <button onclick="editNote(${note.id}, '${note.title}', '${note.content}')">Edit</button>
            <button onclick="deleteNote(${note.id})">Delete</button>
        </div>
    `).join('');
}

noteForm.addEventListener('submit', async (e) => {
    e.preventDefault();
    const id = noteId.value;
    const title = noteTitle.value;
    const content = noteContent.value;

    if (id) {
        
        await fetch(apiUrl, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: parseInt(id), title, content })
        });
    } else {
        
        await fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, content })
        });
    }

    noteForm.reset();
    fetchNotes();
});


async function deleteNote(id) {
    await fetch(`${apiUrl}/${id}`, { method: 'DELETE' });
    fetchNotes();
}

function editNote(id, title, content) {
    noteId.value = id;
    noteTitle.value = title;
    noteContent.value = content;
}

fetchNotes();
