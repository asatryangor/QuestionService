import React, {Component} from 'react';
import {connect} from "react-redux";
import {question} from "../actions/question";

class Question extends Component {
    componentDidMount(): void {
        this.props.question(this.props.match.params.id)
            .then(() => {

            }).catch(e => {

        });
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-12">
                    <span>{this.props.questionData && this.props.questionData.text}</span>
                </div>
            </div>
        );
    }
}

export default connect(state => ({
    loaded: state.questionReducer.loaded,
    error: state.questionReducer.error,
    questionData: state.questionReducer.data
}), {
    question
})(Question);