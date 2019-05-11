import { QuestionsActions } from "../constants/QuestionsActions"

const questionReducer = (state = {loaded: false, data: null}, action) => {
    switch (action.type) {
        case QuestionsActions.GetQuestionRequest:
            return {
                ...state,
                loaded: false
            };
        case QuestionsActions.QuestionGetSuccess:
            return {
                ...state,
                loaded: true,
                data: action.data
            };
        case QuestionsActions.QuestionGetError:
            return {
                ...state,
                loaded: false
            };
        default:
            return state;
    }
};

export default questionReducer;