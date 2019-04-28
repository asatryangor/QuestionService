import { AuthActions } from "../constants/AuthActions"

const authReducer = (state = {loading: false, isAuth: localStorage.getItem('token') != null}, action) => {
    console.log(state);
    switch (action.type) {
        case AuthActions.LoginRequest:
            return {
                ...state,
                loading: true,
                isAuth: false
            };
        case AuthActions.LoginSuccess:
            return {
                ...state,
                loading: false,
                role: action.role,
                isAuth: true
            };
        case AuthActions.LoginError:
            return {
                ...state,
                loading: false,
                error: action.error,
                isAuth: false
            };
        default:
            return state;
    }
};

export default authReducer;