import "./styles.css";

export default function App() {
    return (
        <div className="App">
            <h1>Hello CodeSandbox</h1>
            <h2>Start editing to see some magic happen!</h2>
            <Hosgeldiniz isim='salih' link='salih'>
                <h3>Selamlar</h3>
            </Hosgeldiniz>
        </div>
    );
}

function Hosgeldiniz(props) {
    console.log(props);
    return (
        <div>
            Hosgeldiniz <IsımGoster ad={props.isim}
                link={props.link} />
            <p>{props.children}</p>
        </div>
    );
}
function IsımGoster(props) {
    return <a href={props.link}>{props.ad || 'misafir'}</a>
}