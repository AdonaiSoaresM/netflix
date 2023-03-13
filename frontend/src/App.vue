<template>
  <RouterView />
</template>

<script>

export default {
  name: 'App',
}
</script>

<style>
@font-face {
  font-family: Roboto;
  src: url("./assets/fonts/Roboto-Regular.ttf");
}
* {
  box-sizing: border-box;
}

#app, html, body {
  height: 100%;
  width: 100%;
  margin: 0px;
  padding: 0px;
  font-family: 'Roboto';
}

*::-webkit-scrollbar {
  display: none;
}

</style>
