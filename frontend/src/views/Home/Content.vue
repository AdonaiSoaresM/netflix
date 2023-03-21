<template lang="">
    <div class="content">
        <h1>Filmes Disponíveis</h1>
        <MovieRow :movies="movies"/>
        <h1>Recomendados para Você</h1>
        <MovieRow :movies="movies"/>
    </div>
</template>
<script>
import { getMovies } from '@/common/service/tmdb.service';
import MovieRow from './MovieRow.vue';

export default {
    components: { MovieRow },
    name: "Content",
    data() {
        return {
            movies: []
        }
    },
    async mounted(){
        let response = await getMovies();
        this.movies = response.items
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
}
</style>