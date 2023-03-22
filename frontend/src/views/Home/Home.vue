<template lang="">
  <div class="home">
    <Header />
    <MovieTarget />
    <Content />
  </div>
</template>
<script>
import Header from "./Header.vue";
import Content from "./Content.vue";
import MovieTarget from "@/components/MovieTarget.vue";

export default {
  components: { Header, Content, MovieTarget },
  name: "Home",
};
</script>
<style scoped>
.home {
    font-family: "Roboto", sans-serif;
    background-color: rgb(25, 25, 25);
    height: 100%;
    overflow: auto;
    scroll-behavior: smooth;
  }

  h1 {
    color: #FFF;
  }
</style>
