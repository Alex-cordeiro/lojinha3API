import axios from "axios";

const api =  axios.create({
    baseURL:"http://localhost:25399/api"
})

export default api