import { get } from "../api/api-tmdb";

export async function getMovies(page){

    var response = await get(`/3/list/${page}`);
    
    return response.data;
}