import React, { Component } from 'react';
import { connect } from 'react-redux';
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
            <div className="container">
                <div className="row">
                    <div className="col-sm-9 col-md-7 col-lg-5">
                        <div className="form-label-group">
                            <label htmlFor="loginInput" className="login col-md-4">Логин</label>
                            <input value={this.state.login} onChange={this.handleLoginChange} type="text"
                                   className="loginInput col-md-8" />
                        </div>
                        <div className="form-label-group">
                            <label htmlFor="passwordInput" className="password col-md-4">Пароль</label>
                            <input value={this.state.pass} onChange={this.handlePassChange} type="password"
                                   className="passwordInput col-md-8" />
                        </div>
                        <button className="btn btn-primary"
                                onClick={this.handleSubmit}>Войти
                        </button>
                        <FacebookLoginButton className="btn btn-facebook">Войти через Facebook</FacebookLoginButton>
                    </div>
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