import {httpAuth} from "../api";
import { AuthActions } from "../constants/AuthActions";

export const register = (login, password, confirmPassword) => (dispatch, getState) => {
    dispatch({
        type: AuthActions.RegisterRequest
    });
    return httpAuth.post('auth/register', {
        Login: login,
        Password: password,
        ConfirmPassword: confirmPassword
    }).then(data => {
        localStorage.setItem('token', data.data.token);
        return dispatch({
            type: AuthActions.RegisterSuccess,
            role: data.data.role
        });
    }).catch(error => {
        return dispatch({
            type: AuthActions.RegisterError,
            error
        });
    });
};