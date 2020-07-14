import Vue from 'vue'
import Vuex from 'vuex'
import decode from 'jwt-decode'
import router from '../router'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    token: null,
    usuario: null,
    seccionpage: '',
    role: null,
    needReload: false
  },
  getters: {
    usuarioData: state => state.usuario
  },
  mutations: {
    setToken(state, token) {
      state.token = token;
    },
    setUsuario(state, usuario) {
      state.usuario = usuario;
    },
    setPage(state, page) {
      state.seccionpage = page;
    },
    setRole(state) {
      state.role = null
    },
    setReload(state, value) {
      state.needReload = value;
    }
  },
  actions: {
    guardarToken({
      commit
    }, token) {
      commit('setToken', token);
      commit('setUsuario', decode(token));
      localStorage.setItem('token', token);
      console.log("Guardado");
    },
    autoLogin({
      commit
    }) {
      let token = localStorage.getItem('token');
      if (!this.state.token && token != null) {
        commit('setToken', token);
        commit('setUsuario', decode(token));
        if (this.state.usuario.exp <= (Date.now() / 1000)) {

          localStorage.removeItem('token');
        }
      }
    },
    salir({
      commit
    }) {
      alert("Usted ha salido de la Sesion");
      commit('setToken', null);
      commit('setUsuario', null);
      commit('setRole');
      localStorage.removeItem('token');
      axios.defaults.headers.common['Authorization'] = null;
      router.push({
        name: "login"
      });

    },
    setSeccionPage({
      commit
    }, page) {
      commit('setPage', page);
    },
    setNeedReload({
      commit
    }, bool) {
      commit('setReload', bool);
    }
  },
  modules: {}
})