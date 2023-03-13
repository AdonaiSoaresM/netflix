import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/Login/Login.vue"

const routes = [
  { path: "/", component: null, name: "Home" },
  { path: "/login", component: Login, name: "Login" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
