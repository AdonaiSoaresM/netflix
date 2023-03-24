<template>
  <div class="form-movie" v-if="toggle">
    <form name="movie" ref="form">
      <h1>Adicionar Filme</h1>

      <InputForm
        class="input"
        :placeholder="'Título do filme'"
        :name="'original_title'"
        @vmodel="updateData"
      />
      <InputForm
        class="input"
        :placeholder="'Descrição'"
        :name="'overview'"
        @vmodel="updateData"
      />
      <div class="year-vote">
        <InputForm
          class="input"
          :type="'number'"
          :placeholder="'Ano lançamento'"
          :name="'year'"
          @vmodel="updateData"
        />
        <InputForm
          class="input"
          :type="'number'"
          :placeholder="'Avaliação'"
          :name="'vote_average'"
          @vmodel="updateData"
        />
      </div>
      <h4>Imagem de capa</h4>
      <input
        class="file-upload"
        type="file"
        name="image-preview"
        id="image-preview"
        ref="image"
      />
      <h4>Imagem de background</h4>
      <input
        class="file-upload"
        type="file"
        name="image-background"
        id="image-background"
      />
      <h4>Video do filme</h4>
      <input class="file-upload" type="file" name="video" id="video" />

      <div class="endform">
        <div class="uploadProgress">
          <div>
            <SpinnerLoading v-if="uploadStatus" />
          </div>
          <p ref="upload">{{ uploadStatus }} {{ uploadProgress }}</p>
        </div>
        <div class="button">
          <button class="back" @click.prevent="closeModal">Voltar</button>
          <button class="save" @click.prevent="sendForm">Salvar</button>
        </div>
      </div>
    </form>
  </div>
</template>
<script>
import InputForm from "./InputForm.vue";
import useModalForm from "@/hooks/useModalForm";
import MovieService from "@/common/service/movie.service";
import SpinnerLoading from "./SpinnerLoading.vue";
import { useToast } from "vue-toastification";

const toast = useToast();
const modal = useModalForm();

export default {
  name: "FormMovie",
  components: { InputForm, SpinnerLoading },
  data() {
    return {
      uploadStatus: "",
      uploadProgress: "",
      toggle: false,
      original_title: "",
      year: "",
      overview: "",
      vote_average: "",
    };
  },
  methods: {
    setToggle(bool) {
      this.toggle = bool;
    },
    updateData(input) {
      this[input.field] = input.value;
    },
    async sendForm() {
      this.uploadStatus = "Uploading";
      const fd = new FormData(this.$refs.form);
      var response = await MovieService.post(fd, this.checkUpload);
      if(response.sucess) this.endUpload(response);
    },
    closeModal() {
      this.uploadStatus = "";
      this.uploadProgress = "";
      modal.close();
      window.location.reload()

    },
    checkUpload(event) {
      let progress = ((event.loaded * 100) / event.total).toString()
      this.uploadProgress = `- ${progress.substring(0, progress.indexOf("."))}%`;
    },
    endUpload(response) {
      if (response.sucess) {
        this.uploadStatus = "Sucessfully";
        this.uploadProgress = "";
      }
      this.$refs.upload.style.color = "green"
      toast.success("Video criado com sucesso.")
    },
  },
  mounted() {
    modal.listen(this.setToggle);
  },
};
</script>
<style scoped>
h1,
h4 {
  color: rgba(255, 255, 255, 0.852);
}

h4 {
  margin-bottom: 10px;
}
.form-movie {
  position: fixed;
  width: 100%;
  height: 100%;
  z-index: 101;
  background-color: rgba(0, 0, 0, 0.579);
  display: grid;
  place-items: center;
  overflow: auto;
}

form {
  background-image: url("@/assets/imgs/background-login.jpg");
  box-shadow: inset 0 0 0 2000px rgb(0, 0, 0);
  width: 500px;
  height: auto;
  border-radius: 6px;
  padding: 50px 60px;
  overflow: auto;
}

.year-vote {
  margin: 0px;
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 5px;
  height: 50px;
}

.file-upload {
  color: white;
}

.file-upload::file-selector-button {
  background-color: rgb(207, 75, 75);
  padding: 5px;
  border: none;
  border-radius: 5px;
  color: white;
}

.button {
  display: flex;
  height: 100%;
  align-items: center;
  flex-direction: row;
  gap: 5px;
}

button {
  padding: 8px 30px;
  border: none;
  font-size: 14px;
  font-weight: 600;
  border-radius: 6px;
  cursor: pointer;
}
button.save {
  background-color: rgb(169, 29, 29);
  color: white;
}

button.back {
  background-color: #353535;
}

.endform {
  margin-top: 20px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  height: 50px;
}

.uploadProgress {
  width: 50%;
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 15px;
  color: #fff;
  font-weight: 600;
}
</style>
