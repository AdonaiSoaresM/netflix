<template lang="">
    <div class="content">
        <h1>Seus Filmes</h1>
        <MyMovies />
        <h1>Recomendados Marvel</h1>
        <MovieRow :movies="moviesHero"/>
        <h1>Recomendados DC</h1>
        <MovieRow :movies="moviesRecommended"/>
    </div>
</template>
<script>
import { getMovies } from '@/common/service/tmdb.service';
import MovieRow from '../../components/MovieRow.vue';
import MyMovies from '@/components/MyMovies.vue';

export default {
    components: { MovieRow, MyMovies },
    name: "Content",
    data() {
        return {
            moviesHero: [],
            moviesRecommended: [],

        }
    },
    async mounted(){
        let response = await getMovies(1);
        this.moviesHero = response.items
        response = await getMovies(3);
        this.moviesRecommended = response.items
    }
}
</script>
<style scoped>

.content {
    overflow: auto;
}


h1 {
    color: #FFF;
    margin-left: 30px;
    margin-top: 0px;
}
</style>