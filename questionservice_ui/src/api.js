import axios from 'axios';

export const http = axios.create({
    baseURL: 'http://localhost:52240/api/',
    timeout: 1000,
    headers: {'X-Custom-Header': 'foobar'}
});

export function setAuthHeader(token) {
    //add header
}