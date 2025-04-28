import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router';
import CountryList from '@/components/CountryList.vue';
import CountryForm from '@/components/CountryForm.vue';
import 'bootstrap/dist/css/bootstrap.min.css'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', name: 'Home', component: CountryList},
        { path: '/country', name: 'CountryForm', component: CountryForm}
    ]
})


createApp(App).use(router).mount('#app')
