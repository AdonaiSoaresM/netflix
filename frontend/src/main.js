import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/router'
import Toast, { POSITION } from "vue-toastification";
import { createStore } from 'vuex';

import "vue-toastification/dist/index.css";
export const store = createStore({
    state: {
        token: null,
      },
    mutations: {
        setToken(state, token) {
            state.token = token;
        },
    },
    })
const optionsToast = {
    position: POSITION.BOTTOM_RIGHT
}

const app = createApp(App)
app.use(router)
app.use(Toast, optionsToast)
app.use(store)
app.mount('#app')
