import { combineReducers } from 'redux';
import authReducer from "./auth";
import questionsReducer from './questions';
import questionReducer from './question';
import  registerReducer from './register';

export default combineReducers({
    authReducer: authReducer,
    questionsReducer: questionsReducer,
    questionReducer: questionReducer,
    registerReducer: registerReducer
});

