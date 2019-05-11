import { httpQuestion } from "../api";
import { QuestionsActions } from "../constants/QuestionsActions";

export const question = (id) => (dispatch, getState) => {
    dispatch({
        type: QuestionsActions.GetQuestionRequest
    });
    return httpQuestion.get('question/' + id)
        .then(response => {
            return dispatch({
                type: QuestionsActions.QuestionGetSuccess,
                data: response.data.data
            });
        }).catch(error => {
            return dispatch({
                type: QuestionsActions.QuestionGetError,
                error
            });
        });
};