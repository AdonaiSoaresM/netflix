import axios from "axios";
import URL_BASE from "../config/config";

function config(){
    return { headers: { Authorization: `Bearer ${window.localStorage.getItem("token")}` }}
}

async function get(url){
    let response;
    await axios.get(`${URL_BASE}/${url}`, config()).then(resp => {
        response = resp.data
    }).catch(error => {
        response = error
    })
    return response
}

async function post(url, body, config){
    let response;

    await axios.post(`${URL_BASE}/${url}`, body, config).then(resp => {
        response = resp.data
    }).catch(error => {
        response = error.response.data
    })
    
    return response
}

export default { post, get }