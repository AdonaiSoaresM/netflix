import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/Login/Login.vue"
import Home from "../views/Home/Home.vue"

const routes = [
  { path: "/", component: Home, name: "Home" },
  { path: "/login", component: Login, name: "Login" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
