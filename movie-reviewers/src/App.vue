<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app clipped>
      <v-list dense>
        <v-list-item link :to="{ name: 'home'}">
          <v-list-item-action>
            <v-icon>mdi-view-dashboard</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link :to="{ name: 'About'}">
          >
          <v-list-item-action>
            <v-icon>mdi-help</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Acerca de</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app clipped-left>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>{{Title}}</v-toolbar-title>
      <template v-if="logueado">
        <v-spacer></v-spacer>
        <span>{{this.$store.state.usuario.fullName }}</span>
        <v-spacer></v-spacer>
        <v-btn @click="salir" icon>
          <v-icon>logout</v-icon>
        </v-btn>
      </template>
    </v-app-bar>

    <v-main>
      <v-container class="fill-height" fluid>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-main>

    <v-footer app>
      <v-row>
        <v-col class="text-center">
          <p class="white--text pt-0">
            Jesus Dicent
            <span>&copy; {{ new Date().getFullYear() }}</span>
          </p>
        </v-col>
      </v-row>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  props: {
    source: String
  },
  data: () => ({
    drawer: null
  }),
  computed: {
    logueado() {
      return this.$store.state.usuario;
    },
    esAdministrador() {
      return (
        this.$store.state.usuario && this.$store.state.usuario.role == "Admin"
      );
    },
    esUser() {
      return (
        this.$store.state.usuario && this.$store.state.usuario.role == "User"
      );
    },
    Title() {
      return process.env.VUE_APP_TITLE;
    }
  },
  created() {
    this.$vuetify.theme.dark = true;
    this.$store.dispatch("autoLogin");
  },
  methods: {
    salir() {
      this.$store.dispatch("salir");
    }
  }
};
</script>