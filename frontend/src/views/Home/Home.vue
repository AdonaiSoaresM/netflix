<template lang="">
  <div class="home">
    <Header />
  </div>
</template>
<script>
import Header from "./Header.vue";

export default {
  components: { Header },
  name: "Home",
};
</script>
<style scoped>
.home {
    font-family: "Roboto", sans-serif;
    background-color: rgb(25, 25, 25);
    height: 100%;
  }

  h1 {
    color: #FFF;
  }
</style>
