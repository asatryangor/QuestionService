import React, { Component } from 'react';
import { connect } from 'react-redux';

import { register } from '../actions/register';

import '../css/auth.css'

class Register extends Component {
    state = {
        login: '',
        pass: '',
        confirmPass: ''
    };
    handleLoginChange = (e) => {
        this.setState({ login: e.target.value })
    };
    handlePassChange = (e) => {
        this.setState({ pass: e.target.value })
    };
    handleConfirmPassChange = (e) => {
        this.setState({ confirmPass: e.target.value })
    };
    handleSubmit = () => {
        this.props.register(this.state.login, this.state.pass, this.state.confirmPass).then(() => {
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
                    <input type="text"
                           value={this.state.confirmPass}
                           onChange={this.handleConfirmPassChange}
                           placeholder="Повторите пароль"/>
                    <button onClick={this.handleSubmit}>Зарегистрироваться</button>
                </div>
            </div>
        );
    }
}

export default connect(state => ({
    loading: state.authReducer.loading,
    error: state.authReducer.error
}), {
    register
})(Register);