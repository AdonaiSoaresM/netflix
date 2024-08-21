<template lang="">
    <div class="textInputWrapper">
        <input :placeholder="placeholder" :type="type" :name="name" class="textInput" v-model="value">
    </div>
</template>
<script>
export default {
    name: "InputForm",
    data() {
        return {
            value: "",
        }
    },
    mounted(){
        this.value = this.initialValue
    },
    props: {
        placeholder: String,
        type: { type: String, default: "text" },
        name: { type: String, required: true },
        initialValue: { type: String, default: ""}
    },
    watch: {
        value(newValue){
            const input = {};
            input.field = this.name;
            input.value = newValue;
            this.$emit('vmodel', input)
        }
    }
}
</script>
<style scoped>
.textInputWrapper {
    position: relative;
    width: 100%;
    margin: 30px 0px;
    --accent-color: #a3e583;
  }
  
  .textInputWrapper:before {
    transition: border-bottom-color 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
    border-bottom: 1px solid rgba(0, 0, 0, 0.42);
  }
  
  .textInputWrapper:before,
  .textInputWrapper:after {
    content: "";
    left: 0;
    right: 0;
    position: absolute;
    pointer-events: none;
    bottom: -1px;
    z-index: 4;
    width: 100%;
  }
  
  .textInputWrapper:focus-within:before {
    border-bottom: 1px solid var(--accent-color);
  }
  
  .textInputWrapper:before {
    transition: border-bottom-color 200ms cubic-bezier(0.4, 0, 0.2, 1) 0ms;
    border-bottom: 1px solid rgba(0, 0, 0, 0.42);
  }
  
  .textInputWrapper:focus-within:before {
    border-bottom: 1px solid var(--accent-color);
    transform: scaleX(1);
  }
  
  .textInputWrapper:focus-within:after {
    border-bottom: 2px solid var(--accent-color);
    transform: scaleX(1);
  }
  
  .textInputWrapper:after {
    content: "";
    transform: scaleX(0);
    transition: transform 250ms cubic-bezier(0, 0, 0.2, 1) 0ms;
    will-change: transform;
    border-bottom: 2px solid var(--accent-color);
    border-bottom-color: var(--accent-color);
  }
  
  .textInput::placeholder {
    transition: opacity 250ms cubic-bezier(0, 0, 0.2, 1) 0ms;
    opacity: 1;
    user-select: none;
    color: rgba(255, 255, 255, 0.582);
  }
  
  .textInputWrapper .textInput {
    border-radius: 5px 5px 0px 0px;
    box-shadow: 0px 2px 5px rgb(35 35 35 / 30%);
    max-height: 50px;
    background-color: #252525;
    transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
    transition-duration: 200ms;
    transition-property: background-color;
    color: #e8e8e8;
    font-size: 15px;
    font-weight: 500;
    padding: 12px;
    width: 100%;
    height: 50px;
    border-left: none;
    border-bottom: none;
    border-right: none;
  }
  
  .textInputWrapper .textInput:focus,
  .textInputWrapper .textInput:active {
    outline: none;
  }
  
  .textInputWrapper:focus-within .textInput,
  .textInputWrapper .textInput:focus,
  .textInputWrapper .textInput:active {
    background-color: #353535;
  }
  
  .textInputWrapper:focus-within .textInput::placeholder {
    opacity: 0;
  }
  
</style>