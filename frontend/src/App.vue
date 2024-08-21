<template>
  <RouterView />
</template>

<script>
import jwtService from './common/service/jwt.service';
import { useToast } from 'vue-toastification';

const toast = useToast()
export default {
  name: 'App',
  async mounted(){
    if(this.$route.name !== "Login" && this.$route.name !== undefined){
    const token = await jwtService.validateToken()
    if(!token){
      this.$router.push("/login")
      toast.error("Please, login again.")
    }
  }
  }
}
</script>

<style>
@font-face {
  font-family: Roboto;
  src: url("./assets/fonts/Roboto-Regular.ttf");
}
@import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');

* {
  box-sizing: border-box;
}

#app, html, body {
  height: 100%;
  width: 100%;
  margin: 0px;
  padding: 0px;
  font-family: 'Roboto';
  overflow: auto;
}

*::-webkit-scrollbar {
  display: none;
}

</style>
