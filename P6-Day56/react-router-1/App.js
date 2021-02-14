import React from "react";
import { BrowserRouter, Route } from "react-router-dom";

import Navbar from "./components/Navbar";
import "./styles.css";
import "bootstrap/dist/css/bootstrap.min.css";
import Home from "./components/Home";
import About from "./components/About";
import Contact from "./components/Contact";

import LogButton from "./components/LogButton";

export default function App() {
    const contact = LogButton(Contact);
    return (
        <div>
            <BrowserRouter>
                <Navbar />
                <div className="container">
                    <Route component={Home} path="/" exact />
                    <Route component={About} path="/about" />
                    <Route component={contact} path="/contact" />
                </div>
            </BrowserRouter>
        </div>
    );
}
