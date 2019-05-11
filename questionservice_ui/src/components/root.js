import React from 'react';
import {Route, Switch} from 'react-router-dom';
import Login from './login';
import Questions from "./questions";
import Question from "./question";

export default function Root () {
    return (
        <Switch>
            <Route path={'/auth'} component={Login}/>
            <Route path={'/question/:id'} component={Question}/>
            <Route path={'/question'} component={Questions}/>
        </Switch>
    );
}