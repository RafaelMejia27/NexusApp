<template>
    <div>
        <nav class="navbar navbar-light" style="background-color: #e3f2fd;">
            <div class="container">
                <div @click="sessionOff" class="btn btn-danger">Cerrar sesion</div>
            </div>
        </nav>
        <div class="container card-flex">
            <div class="" v-for="(value, index) in info" :key="index">
                <div class="card mt-5 ms-5 card-style">
                    <div class="card-body">
                        <h5 class="card-title">{{value.description}}</h5>
                        <h6 class="card-subtitle mb-2 text-muted">{{value.supplier}}</h6>
                        <p class="card-text"> Precio a pagar: ${{value.priceToPay}}</p>
                        <p class="card-text">Peso: {{value.weight}}</p>
                        <p class="card-text">Courier: {{value.courier}}</p>
                        <p class="card-text">CourierTracking: {{value.courierTracking}}</p>
                        <p class="card-text">InternalTracking: {{value.internalTracking}}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

import axios from "axios";
import { API_URL } from "@/common/config";

export default ({
    data() {
        return{
            info : null
        }
    },
    created() {
        this.getPackages()
    },
    methods: {
        getPackages(){
            axios
                .get(API_URL + 'Login/getPackage')
                .then(response => (this.info = response.data.responseObject))
        },
        sessionOff(){
            localStorage.setItem("isLogin",false);
            window.location.reload();
        },
    }
})
</script>
