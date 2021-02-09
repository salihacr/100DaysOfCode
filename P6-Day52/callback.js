// calback

const todos = [
    { title: "Todo 1", description: "tanım1" },
    { title: "Todo 2", description: "tanım2" },
    { title: "Todo 3", description: "tanım3" }
];
const todoListEl = document.getElementById('todoList');

function todoList() {
    setTimeout(() => {
        let html = "";
        todos.forEach(todo => {
            html += `
                    <li>
                        <b>${todo.title}</b>
                        <p>${todo.description}</p>
                    </li>
            `;
        });
        todoListEl.innerHTML = html;
    }, 1000);
}

function newTodo(todo, callback) {
    setTimeout(() => {
        todos.push(todo);
        callback();
    }, 2000);
}
newTodo(
    { title: "todo 4", description: "dasdada" },
    todoList);

//todoList();