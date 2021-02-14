import React from "react";
import { Link } from "react-router-dom";

const CountryCard = ({ country }) => {
    return (
        <div className="card mb-2">
            <div className="card-body">
                <Link to={"/" + country.name}>
                    <h5 className="card-title">{country.name}</h5>
                </Link>
                <p>{country.nativeName}</p>
            </div>
        </div>
    );
};

export default CountryCard;
