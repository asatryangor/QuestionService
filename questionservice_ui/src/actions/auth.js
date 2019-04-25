import { http } from "../api";

export const login = (login, pass) => (dispatch, getState) => {
    dispatch({
        type: "LOGIN_REQUEST"
    });

    return http.post('auth/login', {
        Login: login, Password: pass
    }).then(data => {
        localStorage.setItem('token', data.token);
        return dispatch({
            type: "LOGIN_SUCCESS",
            role: data.role
        });
    }).catch(error => {
        return dispatch({
            type: "LOGIN_ERROR",
            error
        });
    });
};