import axios from "axios";
import { URL_APIMOVIE, APIMOVIE_TOKEN } from "../config/config";

let params = {
    api_key: APIMOVIE_TOKEN
};

export async function get(url){
    let response;
    await axios.get(`${URL_APIMOVIE}${url}`,{ params }).then(resp => {
        response = resp;
    });
    return response;
}