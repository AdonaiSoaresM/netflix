<template>
    <div class="movie-row">
        <button @click="scrollAnimation(-15)">﹤</button>
        <div class="movies" ref="movies">
            <div class="movie-img" v-for="(movie, index) in movies" :key="index">
                <img :src="`https://image.tmdb.org/t/p/w500${movie.poster_path}`" alt="movie">
            </div>
        </div>
        <button class="buttonNext" @click="scrollAnimation(15)"> ﹥</button>
    </div>
</template>
<script>
export default {
    name: "MovieRow",
    props: {
        movies: Array,
    },
    methods: {
        async scrollAnimation(x){
            for(var i = 0; i < 30; i++){
                await new Promise(res => {
                    setTimeout(() => {
                        res(this.$refs.movies.scrollBy(x, 0))
                    }, 0)
                })
            }
        },
    }
}
</script>
<style scoped>

.movie-row {
    display: flex;
    align-items: center;
}

button {
    z-index: 99;
    display: block;
    height: 200px;
    border: none;
    color: white;
    width: 30px;
    font-size: 30px;
    padding: 0px;
    font-weight: 1000;
    background-color: rgba(0, 0, 0, 0.801);
    float: left;
    opacity: 0;
    transition: all ease 0.5s;
}
.buttonNext {
    float: right;
}

.movies{
    padding-left: 20px;
    overflow: auto;
    display: flex;
    gap: 20px;
    align-items: center;
    height: 280px;
}

.movie-row:hover button {
    opacity: 1;
}
.movie-img {
    width: 500px;
    height: 280px;
    display: inline-block;
}

.movie-img img {
    width: 180px;
    transform: scale(0.9);
    transition: all ease 0.3s;
}
.movie-img img:hover {
    transform: scale(1);
}

</style>