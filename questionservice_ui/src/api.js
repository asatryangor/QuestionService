import axios from 'axios';
import { ApiBaseURL } from "./constants/ApiBaseURL"

export const httpAuth = axios.create({
    baseURL: ApiBaseURL.AuthUrl,
    timeout: 1000,
    headers: {'X-Custom-Header': 'foobar'}
});

export const httpQuestion = axios.create({
    baseURL: ApiBaseURL.QuestionUrl,
    timeout: 1000,
    headers: {'X-Custom-Header': 'foobar'}
});

export function setAuthHeader(token) {
    //add header
}