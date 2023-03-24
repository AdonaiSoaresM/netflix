<template lang="">
    <div class="headermovie">
        <img src="../../assets/imgs/netflix_logo.png" alt="netflix_logo" width="200">
    </div>
</template>
<script>

export default {
    name: "HeaderHome",
}
</script>
<style scoped>
.headermovie {
    display: flex;
    align-items: center;
    justify-content: space-between;
    width: 100%;
    height: 100px;
    padding: 0px 40px 0px 20px;
    z-index: 100;
    position: fixed;
    margin-bottom: 10px;
}

.user-avatar {
    border-radius: 5px;
}
</style>