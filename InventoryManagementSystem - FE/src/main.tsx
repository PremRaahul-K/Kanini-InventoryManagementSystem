import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import store from "./store/configureStore";
import "./index.css";
import App from "./App";
import { StrictMode } from "react";

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root")
);
