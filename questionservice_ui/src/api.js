import axios from 'axios';
import { ApiBaseURL } from "./constants/ApiBaseURL"

export const httpAuth = axios.create({
    baseURL: ApiBaseURL.AuthUrl,
    timeout: 1000,
    headers: null
});

export const httpQuestion = axios.create({
    baseURL: ApiBaseURL.QuestionUrl,
    timeout: 1000,
    headers: null
});

export function setHTTPHeader (header, value) {
    if (header === "Authorization") {
        httpAuth.defaults.headers[header] = 'bearer ' + value;
        httpQuestion.defaults.headers[header] = 'bearer ' + value;
    }
    else {
        httpAuth.defaults.headers[header] = value;
        httpQuestion.defaults.headers[header] = value;
    }
}