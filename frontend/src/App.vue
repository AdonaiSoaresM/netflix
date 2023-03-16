<template>
  <RouterView />
</template>

<script>
import jwtService from './common/service/jwt.service';
import router from './router/router';
import { useToast } from 'vue-toastification';

const toast = useToast()
router.beforeEach(async (to) => {
  if(to.name != "Login"){
    const token = await jwtService.validateToken()
    if(!token){
      router.push("/login")
      toast.error("Please, login again.")
    }
  }
})

export default {
  name: 'App',
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
}

*::-webkit-scrollbar {
  display: none;
}

</style>
