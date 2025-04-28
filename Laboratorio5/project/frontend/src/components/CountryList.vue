<template>
<div class="container mt-5">
    <h1 class="display-4 text-center">Lista de Países</h1>

    <div class="row justify-content-end">
        <div class="col-2">
            <router-link to="/country" class="btn btn-outline-secondary">
                Agregar País
            </router-link>
        </div>
    </div>
    
    <table class="table">
        <thead>
            <tr>
                <th>Nombre</th>
                <th>Continente</th>
                <th>Idioma</th>
                <th>Acciones</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="(country,index) of countries" :key="index">
                <template v-if="!country.isBeingEdited">
                    <td>{{ country.name }}</td>
                    <td>{{ country.continent }}</td>
                    <td>{{ country.language }}</td>
                </template>

                <template v-else>
                    <td><input type="text" v-model="country.name"></td>
                    <td><input type="text" v-model="country.continent"></td>
                    <td><input type="text" v-model="country.language"></td>
                </template>
                <td>
                    <div v-if="!country.isBeingEdited" class="d-flex gap-2">
                        <button class="btn btn-secondary btn-sm" @click="editCountry(index)">Editar</button>
                        <button class="btn btn-danger btn-sm" @click="deleteCountry(index)">Eliminar</button>
                    </div>

                    <button v-else class="btn btn-primary btn-sm" @click="acceptCountryChanges(index)">Aceptar</button>
                </td>
            </tr>
        </tbody>
    </table>
</div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'CountryList',
    data() {
        return {
            countries: [],
        }
    },
    methods: {
        getCountries() {
            axios.get('https://localhost:5000/api/Countries').then((response) => {
                this.countries = response.data;
            });
        },
        deleteCountry(index) {
            if (typeof index == 'number') {
                this.countries.splice(index, 1)
            }
        },
        editCountry(index) {
            if (typeof index == 'number') {
                this.countries[index].isBeingEdited = true;
            }
        },
        acceptCountryChanges(index) {
            if (typeof index == 'number') {
                this.countries[index].isBeingEdited = false;
            }
        }
    },
    created() {
        this.getCountries();
    }
}
</script>

<style lang="scss" scoped>

</style>