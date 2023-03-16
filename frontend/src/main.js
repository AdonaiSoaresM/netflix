import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/router'
import Toast, { POSITION } from "vue-toastification";

import "vue-toastification/dist/index.css";

const optionsToast = {
    position: POSITION.BOTTOM_RIGHT
}

const app = createApp(App)
app.use(router)
app.use(Toast, optionsToast)
app.mount('#app')
