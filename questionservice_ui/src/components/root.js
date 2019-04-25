import React from 'react';
import {Route, Switch} from 'react-router-dom';
import Login from './login';
import AuthRoute from "./auth-route";
import Home from "./home";

export default function Root () {
    return (
        <Switch>
            <Route path={'/auth'} component={Login}/>
            <AuthRoute path={'/'} component={Home}/>
        </Switch>
    );
}