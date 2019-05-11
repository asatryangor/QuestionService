import { combineReducers } from 'redux';
import authReducer from "./auth";
import questionsReducer from './questions';
import questionReducer from './question'

export default combineReducers({
    authReducer: authReducer,
    questionsReducer: questionsReducer,
    questionReducer: questionReducer
});

