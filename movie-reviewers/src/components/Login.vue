<template>
  <v-layout align-center justify-center>
    <v-flex xs12 sm8 md6 lg5 xl4>
      <v-card>
        <v-toolbar dark color="blue darken-3">
          <v-toolbar-title>Acceso al Sistema</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-text-field
            v-model="username"
            autofocus
            color="accent"
            label="Nombre de Usuario"
            required
          ></v-text-field>
          <v-text-field
            v-model="password"
            type="password"
            color="accent"
            label="Contraseña"
            required
          ></v-text-field>
          <v-flex v-if="error">{{ error }}</v-flex>
          <v-card-actions class="px-3 pb-3">
            <v-flex class="red--text" text-xs-right>
              <v-btn @click="ingresar" color="primary">Ingresar</v-btn>
            </v-flex>
          </v-card-actions>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      username: "",
      password: "",
      error: null
    };
  },
  methods: {
    ingresar() {
      let me = this;
      me.error = null;
      var url = process.env.VUE_APP_BASE_URL + "Login";
      axios
        .post(url, {
          userName: me.username,
          password: me.password
        })
        .then(respuesta => {
          return respuesta.data;
        })
        .then(data => {
          me.$store.dispatch("guardarToken", data.token);          
        })
        .catch(err => {
          if (err.response.status == 400) {
            me.error = "No es un username valido";
          } else if (err.response.status == 404) {
            me.error =
              "El Usuario no existe, o las credenciales estan incorrectas";
          } else {
            me.error = "Ha Ocurrido un error";
          }
          //console.log(err);
        });
    }
  }
};
</script>
