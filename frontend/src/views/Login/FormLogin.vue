<template>
  <div class="formLogin">
    <h1>Entrar</h1>
    <InputFormLogin
      :placeholder="'E-mail'"
      :name="'email'"
      @vmodel="updateData"
    />
    <InputFormLogin
      :placeholder="'Senha'"
      :name="'senha'"
      :type="'password'"
      @vmodel="updateData"
    />
    <button class="entrar" @click="login">Entrar</button>
    <div class="lembrese">
      <input
        type="checkbox"
        name="lembrese"
        class="checkbox"
        v-model="lembrese"
      />
      Lembre-se de mim
    </div>
  </div>
</template>
<script>
import { useToast } from "vue-toastification";
import InputFormLogin from "./InputFormLogin.vue";
import loginService from "@/common/service/jwt.service";

const toast = useToast();

export default {
  components: { InputFormLogin },
  name: "FormLogin",
  data() {
    return {
      email: "",
      senha: "",
      lembrese: "",
    };
  },
  methods: {
    updateData(input) {
      this[input.field] = input.value;
    },
    async login() {
      const login = { email: this.email, password: this.senha };
      const response = await loginService.login(login);
      this.validateResponse(response)
    },
    validateResponse(response){
      if(response.sucess){
        this.$router.push("/")
      } else {
        toast.error("Login failed, please try again.")
      }
    }
  },
};
</script>
<style scoped>
.formLogin {
  height: 550px;
  width: 100%;
  max-width: 450px;
  background-color: #000000c6;
  font-weight: 100;
  border-radius: 4px;
  padding: 60px;
  overflow-y: auto;
}

h1 {
  color: rgb(255, 255, 255);
}

.entrar {
  width: 100%;
  height: 50px;
  background-color: #e50914;
  color: rgb(255, 255, 255);
  border: none;
  border-radius: 6px;
  margin-top: 50px;
  font-weight: 600;
  font-size: 16px;
  cursor: pointer;
}

.lembrese {
  color: gray;
  font-size: 14px;
  margin-top: 15px;
  display: flex;
  justify-items: center;
  align-items: center;
  gap: 10px;
}

@media (max-width: 700px) {
  .formLogin {
    width: 350px;
  }
}
</style>
