import api from "../api/api";

async function get(){
  let response;
  await api.get("movie/get").then(data => {
    response = data;
  })
  return response;
}

async function post(formData, callback){
    let response;
    await api.post("movie/add", formData, {
      onUploadProgress: callback
    }).then(data => {
        response = data;
      })
    return response
}

export default { get, post }