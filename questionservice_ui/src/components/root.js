import React from 'react';
import {Route, Switch} from 'react-router-dom';
import Login from './login';
import Questions from "./questions";
import Question from "./question";
import Register from "./register";

export default function Root () {
    return (
        <Switch>
            <Route path={'/auth'} component={Login}/>
            <Route path={'/register'} component={Register}/>
            <Route path={'/question/:id'} component={Question}/>
            <Route path={'/'} component={Questions}/>
        </Switch>
    );
}