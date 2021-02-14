import React from "react";
import CountryCard from "./CountryCard";

import axios from "axios";

class CountryList extends React.Component {
    state = {
        countries: []
    };
    componentDidMount() {
        axios.get("https://restcountries.eu/rest/v2/all").then((response) => {
            console.log(response.data);
            this.setState({
                countries: response.data.slice(0, 20)
            });
        });
    }
    handleChange = (e) => {
        console.log(e.target.value);
        if (e.target.value) {
            axios
                .get(`https://restcountries.eu/rest/v2/name/${e.target.value}`)
                .then((res) => {
                    console.log(res.data);
                    this.setState({
                        countries: res.data
                    });
                });
        }
    };
    render() {
        const countryList = this.state.countries.map((country) => {
            return <CountryCard country={country} key={country.numericCode} />;
        });
        return (
            <div>
                <input
                    type="text"
                    name="search"
                    className="form-control mb-3"
                    placeholder="Search Country By Name"
                    onChange={this.handleChange}
                />
                <div className="card-columns">{countryList}</div>
            </div>
        );
    }
}
export default CountryList;
