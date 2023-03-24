<template lang="">
    <div class="spinner">
        <div class="spinnerin"></div>
    </div>
</template>
<script>
export default {
    name: "Spinner"
}
</script>
<style scoped>
.spinner {
    width: 1em;
    height: 1em;
    cursor: not-allowed;
    border-radius: 50%;
    border: 2px solid #444;
    box-shadow: -5px -5px 5px #6359f8, 0px -5px 5px 0px #9c32e2, 5px -5px 5px #f36896, 5px 0 5px #ff0b0b, 5px 5px 5px 0px#ff5500, 0 5px 5px 0px #ff9500, -5px 5px 5px 0px #ffb700;
    animation: rot55 0.7s linear infinite;
  }
  
  .spinnerin {
    border: 2px solid #444;
    width: 1.5em;
    height: 1.5em;
    border-radius: 50%;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
  }
  
  @keyframes rot55 {
    to {
      transform: rotate(360deg);
    }
  }
  
</style>