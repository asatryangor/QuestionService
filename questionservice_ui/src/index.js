import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import * as serviceWorker from "./serviceWorker";
import "bootstrap/dist/css/bootstrap.css";
import "@fortawesome/free-solid-svg-icons";
import "@fortawesome/react-fontawesome";
import "@fortawesome/fontawesome-svg-core";
import store from "./store";
import { Provider } from "react-redux";
import {HashRouter, NavLink} from 'react-router-dom';
import Root from "./components/root";

ReactDOM.render(
    <Provider store={store}>
        <HashRouter>
            <nav className="navbar navbar-expand-md bg-dark navbar-dark sticky-top">
                <NavLink to={`/`} className="navbar-brand">Вопросы и ответы</NavLink>
                <button className="navbar-toggler navbar-toggler-right"
                        type="button"
                        data-toggle="collapse"
                        data-target="#navb"
                        aria-expanded="true">
                    <span className="navbar-toggler-icon"/>
                </button>
                <div id="navb" className="navbar-collapse collapse hide">
                    <ul className="nav navbar-nav ml-auto">
                        <NavLink className="nav-item" to={`/register`}>
                            Зарегистрироваться
                        </NavLink>
                        <NavLink className="nav-item" to={`/auth`}>
                            Войти
                        </NavLink>
                    </ul>
                </div>
            </nav>
            <div className="container">
                <Root />
            </div>
        </HashRouter>
    </Provider>,
    document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
