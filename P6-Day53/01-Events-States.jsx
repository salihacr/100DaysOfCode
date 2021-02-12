import "./styles.css";
import React, { useState } from "react";

export default function App() {
    const [username, setUsername] = useState("");
    const [isLogged, setIsLogged] = useState(false);
    const [errorMessage, setErrorMessage] = useState("");

    const handleChange = (event) => setUsername(event.target.value);

    const handleSubmit = (inputName) => {
        if (inputName.length < 6) {
            setErrorMessage("Username cannot be less than 6 characters.")
        }
        else {
            setErrorMessage("")
            setIsLogged(true);
        }
    };

    return (
        <div
            className="App"
            onClick={() => {
                console.log("clicked App div");
            }}
        >
            {isLogged ?
                (
                    <div>
                        <h1>Welcome, {username}</h1>
                        <button onClick={() => setIsLogged(false)}>Logout</button>
                    </div>
                )
                : (
                    <div>
                        <h1>React Dersleri</h1>
        Name : <input name="inputName" value={username} onChange={handleChange} />
                        <button onClick={() => handleSubmit(username)}>
                            Submit
        </button>
                        <p>
                            Your Name is :<span id="username">{username}</span>
                        </p>
                        {errorMessage ? <h4>{errorMessage}</h4> : <h4>Login</h4>}
                    </div>
                )}

        </div>
    );
}
