import { get } from "../api/api-tmdb";

export async function getMovies(){

    var response = await get("/3/list/1");
    
    return response.data;
}