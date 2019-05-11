import { AuthActions } from "../constants/AuthActions"

const registerReducer = (state = {loaded: false, data: []}, action) => {
    switch (action.type) {
        case AuthActions.RegisterRequest:
            return {
                ...state,
                loaded: false
            };
        case AuthActions.RegisterSuccess:
            return {
                ...state,
                loaded: true,
                data: action.data
            };
        case AuthActions.RegisterError:
            return {
                ...state,
                loaded: false
            };
        default:
            return state;
    }
};

export default registerReducer;