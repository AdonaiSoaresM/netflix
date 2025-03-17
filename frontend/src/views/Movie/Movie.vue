<template lang="">
  <div class="movie">
    <Header />
    <video controls autoplay ref="video"></video>
  </div>
</template>
<script>
import Header from "./Header.vue";
import URL_BASE from "@/common/config/config";
import Hls from "hls.js";

export default {
  name: "Movie",
  components: { Header },
  data() {
    return {
      urlVideo: "",
    };
  },
  methods: {
    renderVideo(id) {
      var video = this.$refs.video;
      var videoSrc = `${URL_BASE}/movie/files/${id}/video.m3u8`;
      const token = this.$store.getters.getToken;
      video.src = videoSrc;
      if (Hls.isSupported()) {
        var config = {
          xhrSetup: function (xhr) {
            xhr.setRequestHeader(
              "Authorization",
              `Bearer ${token}`
            );
          },
        };
        var hls = new Hls(config);
        hls.loadSource(videoSrc);
        hls.attachMedia(video);
      } else if (video.canPlayType("application/vnd.apple.mpegurl")) {
        video.src = videoSrc;
      }
    },
  },
  mounted() {
    const query = this.$route.query;
    if (query.id) {
      this.renderVideo(query.id);
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
