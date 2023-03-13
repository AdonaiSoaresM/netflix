<template>
  <div class="login">
    <Header />
    <Form />
  </div>
</template>
<script>
import Header from "./Header.vue";
import Form from "./FormLogin.vue"
export default {
  components: { Header, Form },
  name: "Login",
};
</script>
<style>
.login {
  width: 100%;
  height: 100%;
  background-image: url("../../assets/imgs/background-login.jpg");
  box-shadow: inset 0 0 0 2000px rgba(0, 0, 0, 0.5);
  display: flex;
  flex-direction: column;
  align-items: center;
}

@media (min-width: 900px) {
  .login {
    background-repeat: round;
  }
}
</style>
