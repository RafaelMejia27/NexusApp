<template>
  <div id="app">
    <Login v-if="isLogin=='false'" />
    <Packages v-if="isLogin=='true'"/>
  </div>
</template>

<script>
import Login from './views/Login/Login.vue'
import Packages from './views/UserPackages/Packages.vue'

export default {
  name: 'App',
  components: {
    Login,
    Packages,
    
  },
    data() {
      return{
          isLogin : false
      }
  },
  created(){
      this.isLogin = localStorage.getItem("isLogin");
  }
}
</script>
