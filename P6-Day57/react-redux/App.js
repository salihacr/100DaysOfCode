import React from "react";
import "./styles.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { useSelector, useDispatch } from "react-redux";
import { increment, decrement } from "./actions/index";

export default function App() {
    const counter = useSelector((state) => state.counter);
    const isLogged = useSelector((state) => state.isLogged);
    const dispatch = useDispatch();
    return (
        <div>
            <h1>Counter {counter}</h1>
            <button onClick={() => dispatch(increment(5))}>+</button>
            <button onClick={() => dispatch(decrement())}>-</button>
            {isLogged ? <h3>Valuable Information I shouldn't see</h3> : ""}
        </div>
    );
}
