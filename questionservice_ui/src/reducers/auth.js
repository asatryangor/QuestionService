//константы
//начальное состояние в зависимости от наличия токена в локал сторадже
const authReducer = (state = {loading: false, isAuth: false}, action) => {
    switch (action.type) {
        case "LOGIN_REQUEST":
            return {
                ...state,
                loading: true,
                isAuth: false
            };
        case "LOGIN_SUCCESS":
            return {
                ...state,
                loading: false,
                role: action.role,
                isAuth: true
            };
        case "LOGIN_ERROR":
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