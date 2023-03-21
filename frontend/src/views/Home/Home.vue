<template lang="">
  <div class="home">
    <Header />
    <Content />
  </div>
</template>
<script>
import Header from "./Header.vue";
import Content from "./Content.vue";

export default {
  components: { Header, Content },
  name: "Home",
};
</script>
<style scoped>
.home {
    font-family: "Roboto", sans-serif;
    background-color: rgb(25, 25, 25);
    height: 100%;
    overflow: auto;
  }

  h1 {
    color: #FFF;
  }
</style>
