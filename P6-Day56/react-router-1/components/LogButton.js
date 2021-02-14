import React from "react";

const LogButton = (WrappedComponent, info) => {
    const handleClick = (e) => {
        console.log("Bileşen LogButton HOC ile geliştirildi");
    };
    return (props) => {
        return (
            <div>
                <button onClick={handleClick}>Log Yaz</button>
                <WrappedComponent {...props} />
            </div>
        );
    };
};

export default LogButton;
