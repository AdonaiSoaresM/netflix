import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/Login/Login.vue";
import Home from "../views/Home/Home.vue";
import Movie from "../views/Movie/Movie.vue";

const routes = [
  { path: "/", component: Home, name: "Home" },
  { path: "/login", component: Login, name: "Login" },
  { path: "/movie", component: Movie, name: "Movie" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
