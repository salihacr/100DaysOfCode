import "./styles.css";
import { Switch, Route, NavLink, Redirect } from "react-router-dom";
import PokemonList from "./components/PokemonList";
import Pokemon from "./components/Pokemon";

export default function App() {
    return (
        <div>
            <nav>
                <NavLink to={"/"}>Search</NavLink>
            </nav>
            <Switch>
                <Route path={"/"} exact component={PokemonList} />
                <Route path={"/pokemon/:pokemon"} exact component={Pokemon} />
                <Redirect to={"/"} />
            </Switch>
        </div>
    );
}
