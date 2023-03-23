<template>
    <div class="movie-row">
        <button @click="scrollAnimation(-15)">﹤</button>
        <div class="movies" ref="movies">
            <div class="movie-item">
                <img :src="`https://image.tmdb.org/t/p/w500/lFByFSLV5WDJEv3KabbdAF959F2.jpg`" alt="movie">
            </div>
            <div class="movie-item">
                <div class="addMovie" @click="addMovie">+</div>
            </div>
        </div>
        <button class="buttonNext" @click="scrollAnimation(15)"> ﹥</button>
    </div>
</template>
<script>
import useModalForm from '@/hooks/useModalForm';

const modal  = useModalForm();

export default {
    name: "MyMovies",
    methods: {
        addMovie(){
            modal.open()
        }
    }
}
</script>
<style scoped>
.movie-row {
    display: flex;
    align-items: center;
}

.addMovie {
    width: 162px;
    height: 270px;
    border: 2px solid #FFF;
    border-radius: 5px;
    display: flex;
    align-items: center;
    color: #FFF;
    font-size: 50px;
    cursor: pointer;
    justify-content: center;
}
.addMovie:hover{
    background-color: rgba(169, 169, 169, 0.178);
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
    padding-left: 0px;
    overflow: auto;
    display: flex;
    gap: 20px;
    align-items: center;
    height: 280px;
    width: 100vw;
}

.movie-row:hover button {
    opacity: 1;
}
.movie-item {
    height: 280px;
    display: flex;
    align-items: center ;
}

.movie-item * {
    width: 180px;
    transform: scale(0.9);
    transition: all ease 0.3s;
}
.movie-img img:hover {
    transform: scale(1);
}
    
</style>