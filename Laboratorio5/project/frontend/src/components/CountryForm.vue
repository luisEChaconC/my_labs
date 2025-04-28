<template>
    <div>
        <h1>Formulario para crear un país</h1>
    </div>

    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
            <h3 class="text-center">Formulario de creación de países</h3>
            <form @submit.prevent="saveCountry">
                <div class="form-group">
                    <label for="name">Nombre</label>
                    <input
                    type="text"
                    id="name"
                    v-model="country.name"
                    class="form-control"
                    required/>
                </div>
                <div class="form-group">
                    <label for="continent">Continente</label>
                    <select
                    id="continent"
                    v-model="country.continent"
                    class="form-control"
                    required>
                        <option value="" hidden>Seleccione un continente</option>
                        <option>África</option>
                        <option>Asia</option>
                        <option>Europa</option>
                        <option>América</option>
                        <option>Oceanía</option>
                        <option>Antártida</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="language">Idioma</label>
                    <input
                    type="text"
                    id="language"
                    v-model="country.language"
                    class="form-control"    
                    required/>
                </div>
                <button type="submit" class="btn btn-success btn-block">Guardar</button>
            </form>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: 'CountryForm',
    data() {
        return {
            country: {
                name: '',
                continent: '',
                language: ''
            }
        }
    },
    methods: {
        saveCountry() {
            console.log(this.country);
            axios.post('https://localhost:5000/api/Countries', {
                name: this.country.name,
                continent: this.country.continent,
                language: this.country.language,
            })
            .then(function(response) {
                console.log(response);
                window.location.href = "/";
            })
            .catch(function(error) {
                console.log(error);
            });
        },
    },
}
</script>

<style lang="scss" scoped>

</style>