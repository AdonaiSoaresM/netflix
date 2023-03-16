<template lang="">
    <div class="header">
        <img src="../../assets/imgs/netflix_logo.png" alt="netflix_logo" width="200">
        <img class="user-avatar" src="@/assets/imgs/netflix_avatar.png" alt="user" width="50" height="50">
    </div>
</template>
<script>
export default {
    name: "HeaderHome"
}
</script>
<style>
.header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    width: 100%;
    padding: 0px 40px 0px 20px;
    background-color: rgb(25, 25, 25);
}

.user-avatar {
    border-radius: 5px;
}
</style>