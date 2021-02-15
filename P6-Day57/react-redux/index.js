import { StrictMode } from "react";
import ReactDOM from "react-dom";
import App from "./App";
import "bootstrap/dist/css/bootstrap.min.css";
import { createStore } from "redux";
import allReducers from "./reducers/index";
import { Provider } from "react-redux";

const store = createStore(allReducers);
const rootElement = document.getElementById("root");
ReactDOM.render(
    <StrictMode>
        <Provider store={store}>
            <App />
        </Provider>
    </StrictMode>,
    rootElement
);
