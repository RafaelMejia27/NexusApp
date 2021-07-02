<template>
    <div>
        <div class="alert alert-danger" role="alert">
            <div v-for="(value, index) in errorList" :key="index">
                <li>{{ value }}</li>
            </div>
        </div>    
    </div> 
</template>

<script> 

export default {
    props: ["errorList"],
    data (){
        return{
        }  
    }, 
    created(){

    },
    methods:{

    }
}

</script>