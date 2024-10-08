<template>
  <div
    v-if="toggle"
    class="movie-target"
    id="movie-target"
    :style="`
    background-image: url(${urlBlob});
    `"
  >
    <div class="overlay-x">
      <div class="overlay-y">
        <div class="movie-info">
          <p class="title">{{ this.movie.original_title }}</p>
          <div class="info">
            <p class="vote">{{ getVote() }} pontos</p>
            <p class="year">2022</p>
          </div>
          <p class="overview">
            {{ this.movie.overview }}
          </p>
          <div class="buttons">
            <button class="play" @click="goToMovie">Assistir</button>
            <button class="list">+ Minha Lista</button>
          </div>
          <p class="genre">
            <strong>Gêneros: </strong> Drama, Comédia, Animação
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import useMovieTarget from "@/hooks/useMovieTarget";
import URL_BASE from "@/common/config/config";
import { useToast } from "vue-toastification";

const toast = useToast();
const event = useMovieTarget();

export default {
  name: "MovieTarget",
  data() {
    return {
      toggle: false,
      movie: null,
      mymovie: false,
      urlBlob: null,
    };
  },
  methods: {
    getVote() {
      let vote = this.movie.vote_average;
      if (vote.toString().includes(".")) {
        return vote;
      } else {
        return vote + ".0";
      }
    },
    async toggleMovie(param) {
      this.animateHeader();
      this.movie = { ...param.movie };
      this.mymovie = param.mymovie;
      await this.sendURLBackground();
      this.toggle = true;
    },
    animateHeader() {
      const home = document.querySelector(".home");
      const header = document.querySelector(".header");
      home.addEventListener("scroll", (event) => {
        if (event.target.scrollTop < 100) {
          header.style.position = "fixed";
          header.style.backgroundColor = "";
        } else {
          header.style.backgroundColor = "rgb(25, 25, 25)";
        }
      });
      home.scrollTo(0, 1000);
      header.style.position = "fixed";
      header.style.backgroundColor = "";
      home.scroll(0, 0);
    },
    async sendURLBackground() {
      if (this.mymovie) {
        await this.setBlobImage();
      } else {
        this.urlBlob = `https://image.tmdb.org/t/p/original${this.movie.backdrop_path}`;
      }
    },
    async setBlobImage() {
      await fetch(
        `${URL_BASE}/movie/files/${this.movie.id}/image-background.jpg`,
        {
          headers: {
            Authorization: `Bearer ${window.localStorage.getItem("token")}`,
          },
        }
      ).then((response) => {
        response.blob().then((blob) => {
          this.urlBlob = URL.createObjectURL(blob);
        });
      });
    },
    goToMovie() {
      if (!this.mymovie) {
        toast.warning("Você só pode assistir os seus filmes.");
        return;
      }
      this.$router.push({
        name: "Movie",
        query: {
          id: this.movie.id,
        },
      });
    },
  },

  mounted() {
    event.listen(this.toggleMovie);
  },
};
</script>
<style scoped>
.movie-target {
  width: 100%;
  height: 100%;
  background-size: auto 90%;
  background-position: right top 0%;
  background-repeat: no-repeat;
}

.movie-info {
  padding-top: 200px;
}

.title {
  color: rgba(255, 255, 255, 0.948);
  font-size: 50px;
  font-weight: 800;
  margin: 0px;
}

.info {
  display: flex;
  font-weight: 600;
  gap: 18px;
  margin-top: 20px;
}

.overview {
  width: 700px;
  color: rgb(164, 158, 158);
}

.buttons {
  display: flex;
  gap: 10px;
  margin-top: 60px;
}

.buttons button {
  padding: 10px 15px;
  font-weight: 600;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
}

button.play {
  background-color: rgb(255, 255, 255, 0.948);
  color: #000;
}

button.list {
  color: rgb(164, 158, 158);
  background-color: rgb(44, 42, 42);
}

button:hover {
  background-color: #686767;
}

.genre {
  color: rgb(164, 158, 158);
  margin-top: 30px;
}

.vote {
  color: rgb(80, 161, 80);
}

.year {
  color: #fff;
  font-weight: 600;
}
.overlay-x {
  width: inherit;
  height: inherit;
  background: linear-gradient(to right, rgb(25, 25, 25) 25%, transparent 90%);
}

.overlay-y {
  width: inherit;
  height: inherit;
  background: linear-gradient(to top, rgb(25, 25, 25) 10%, transparent 90%);
  padding-left: 30px;
}
</style>
