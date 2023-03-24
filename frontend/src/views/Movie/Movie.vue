<template lang="">
  <div class="movie">
    <Header />
    <video :src="urlVideo" controls autoplay></video>
  </div>
</template>
<script>
import Header from "./Header.vue";
import URL_BASE from "@/common/config/config";

export default {
  name: "Movie",
  components: { Header },
  data() {
    return {
      urlVideo: "",
    };
  },
  mounted() {
    const query = this.$route.query;
    console.log(query);
    if (query.id) {
      this.urlVideo = `${URL_BASE}/movie/files/video_${query.id}.mp4`;
    } else {
      this.$router.push("/");
    }
  },
};
</script>
<style scoped>
.movie {
  display: flex;
  flex-direction: column;
  background-color: rgb(25, 25, 25);
  height: 100%;
  overflow: auto;
}

video {
  width: 100%;
  height: 100%;
}
</style>
