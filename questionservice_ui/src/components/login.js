import React, { Component } from 'react';
import { connect } from 'react-redux';
import '../css/auth.css';
import { FacebookLoginButton } from "react-social-login-buttons";

import { login } from '../actions/auth';

class Login extends Component {
    state = {
        login: '',
        pass: ''
    };
    handleLoginChange = (e) => {
        this.setState({ login: e.target.value })
    };
    handlePassChange = (e) => {
        this.setState({ pass: e.target.value })
    };
    handleSubmit = () => {
        this.props.login(this.state.login, this.state.pass).then(() => {
            this.props.history.push('/');
        });
    };

    render() {
        return (
            <div className="login-page">
                <div className="form">
                    <input type="text"
                           value={this.state.login}
                           onChange={this.handleLoginChange}
                           placeholder="Логин"/>

                    <input type="password"
                           value={this.state.pass}
                           onChange={this.handlePassChange}
                           placeholder="Пароль"/>
                    <button onClick={this.handleSubmit}>Войти</button>
                    <FacebookLoginButton className="btn btn-facebook">Войти через Facebook</FacebookLoginButton>
                </div>
            </div>
        );
    }
}

export default connect(state => ({
    loading: state.authReducer.loading,
    error: state.authReducer.error
}), {
    login
})(Login);