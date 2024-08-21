import api from "../api/api";
import { store } from "@/main.js";

async function login(body){
    const response = await api.post("user/login", body)
    
    if(response.sucess) 
       store.commit("setToken", response.data.token)

    return response
}

async function validateToken(){
    let response;
    await api.get("user/validate")
        .then(resp =>  {
            if(resp.status) response = true})
        .catch(() => {
            response = false});

    return response
    
}

export default { login, validateToken}

