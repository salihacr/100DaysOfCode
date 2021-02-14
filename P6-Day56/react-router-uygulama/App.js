import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import "./styles.css";
import "bootstrap/dist/css/bootstrap.min.css";
import CountryList from "./components/CountryList";
import Country from "./components/Country";
import Navbar from "./components/Navbar";

export default function App() {
    return (
        <div>
            <BrowserRouter>
                <Navbar />
                <div className="container mt-2">
                    <Switch></Switch>
                    <Route component={CountryList} path="/" exact />
                    <Route component={Country} path="/:name" />
                </div>
            </BrowserRouter>
        </div>
    );
}
