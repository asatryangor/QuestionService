import React from 'react';
import {Route, Redirect} from 'react-router-dom';
import {connect} from "react-redux";


const AuthRoute = ({component: Component, isAuth, ...other}) =>
    <Route {...other}
           render={props => isAuth
               ? <Component {...props}/>
               : <Redirect to={'/auth'}/>}/>;

export default connect(state => ({
    isAuth: state.authReducer.isAuth
}))(AuthRoute);