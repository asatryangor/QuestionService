import { httpAuth } from "../api";
import { AuthActions } from "../constants/AuthActions";

export const login = (login, password) => (dispatch, getState) => {
    dispatch({
        type: AuthActions.LoginRequest
    });

    return httpAuth.post('auth/login', {
        Login: login, Password: password
    }).then(data => {
        localStorage.setItem('token', data.data.token);
        return dispatch({
            type: AuthActions.LoginSuccess,
            role: data.data.role
        });
    }).catch(error => {
        return dispatch({
            type: AuthActions.LoginError,
            error
        });
    });
};