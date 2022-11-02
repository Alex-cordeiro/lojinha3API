import axios from "axios";
import { getToken } from "../service/token.service";

const api = axios.create({
    withCredentials: true,
    baseURL:"http://localhost:5000/api/"
})


const errorHandler = (error: any) => {
    const statusCode = error.response?.status
  
    // logging only errors that are not 401
    if (statusCode && statusCode !== 401) {
      console.error(error)
    }
  
    return Promise.reject(error)
}

// registering the custom error handler to the
// "api" axios instance
api.interceptors.response.use(undefined, (error) => {
    return errorHandler(error)
  })


api.interceptors.request.use(
    config => {
        const token = getToken;
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        // config.headers['Content-Type'] = 'application/json';
        return config;
    },
    error => {
        Promise.reject(error)
    }
);

export default api;