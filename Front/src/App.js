import logo from "./logo.svg";
import "./App.css";
import { UrlShortener } from "./components/UrlShortener";
import { UrlRedirector } from "./components/UrlRedirector";

function App() {
  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6 col-xs-12">
          <UrlShortener />
        </div>
        <div className="col-md-6 col-xs-12">
          <UrlRedirector />
        </div>
      </div>
    </div>
  );
}

export default App;
