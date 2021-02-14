import React from "react";
import axios from "axios";

class Country extends React.Component {
    state = {
        country: {}
    };
    componentDidMount() {
        let name = this.props.match.params.name;

        axios
            .get(`https://restcountries.eu/rest/v2/name/${name}?fullText=true`)
            .then((response) => {
                console.log(response.data[0]);
                this.setState({
                    country: response.data[0]
                });
            });
    }
    render() {
        const { country } = this.state;
        console.log(country);
        return (
            <div className="card">
                <div className="card-body">
                    <h3 className="card-title"> Ülke Adı : {country.name} </h3>
                    <span>{country.nativeName}</span>
                    <hr />
                    <div className="row">
                        <dt className="col-sm-4">Capital:</dt>
                        <dd className="col-sm-8"> {country.capital}</dd>

                        <dt className="col-sm-4">Population:</dt>
                        <dd className="col-sm-8"> {country.population}</dd>

                        <dt className="col-sm-4">Area:</dt>
                        <dd className="col-sm-8"> {country.area}</dd>
                    </div>
                </div>
                <div className="card-footer">
                    <img src={country.flag} alt="card-img-top" />
                </div>
            </div>
        );
    }
}
export default Country;
