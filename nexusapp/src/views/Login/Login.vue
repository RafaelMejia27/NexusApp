<template>
  <div>

    <div class="wrapper fadeInDown">
  <div id="formContent">

    <div class="fadeIn first">
      <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
        <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"/>
      </svg>
    </div>
      <div class="container">
        <CError v-if="showError" :errorList="errorList" />
      </div>
      <input v-model="username" maxlength="10" type="text" id="login" class="fadeIn second" name="login" placeholder="login" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122))">
      <input v-model="password" type="text" id="password" class="fadeIn third" name="login" placeholder="password" onkeypress="return ((event.charCode >= 48 && event.charCode <= 57) || (event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122))">
      <input @click="checkTryCount" type="button" class="fadeIn fourth" value="Log In">
  </div>
    </div>


  </div>
</template>

<script>

import CError from "@/components/CError"
import axios from "axios";
import { API_URL } from "@/common/config";

export default {
  name: 'Login',
  components: {
    CError
  },
  data(){
    return{
      username: '',
      password: '',
      dataSuccess: false,
      errorList: [],
      showError: false,
      tryCount: 0,
    }
  },
  methods:{
    checkTryCount(){
      this.dataSuccess = true
      this.errorList = []
      if(this.tryCount < 3){
        this.validateData()
      }else{
        this.errorList.push("Ha excedido el numero maximo de intentos para iniciar sesion.")
        this.showError = true
      }
    },
    validateData(){
        if(this.username == '' || ! /^[a-zA-Z0-9]+$/.test(this.username)){
          this.errorList.push('Debe indicar su nombre de usuario y no debe contener caracteres especiales.')
          this.dataSuccess = false
        }
        if(this.password == '' || ! /^[a-zA-Z0-9]+$/.test(this.password)){
            this.errorList.push('Debe ingresar su contraseña y no debe contener caracteres especiales.')
            this.dataSuccess = false
        }

        if(this.dataSuccess){
            this.showError = false
            this.login();
        }else{ 
            this.showError = true;
        }
    },
  login(){
    let json = {
      "username" : this.username,
      "password" : this.password
    };

    axios.post(API_URL + 'Login/Login', json)
    .then( data => {
      if(data.data.success == true){
        localStorage.setItem("isLogin",true);
        window.location.reload();
        }else{
          this.errorList.push(data.data.exception)
          this.tryCount++;
          this.showError = true;
        }
    })

    },
  }

}
</script>