"use strict";

import Vue from 'vue';
import axios from "axios";
import router from '../router';
import store from '../store'
import jwtDecode from 'jwt-decode';

// Full config:  https://github.com/axios/axios#request-config
axios.defaults.baseURL = process.env.VUE_APP_ROOT_API || process.env.apiUrl || '';
// axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
// axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

let config = {
  // baseURL: process.env.baseURL || process.env.apiUrl || ""
  // timeout: 60 * 1000, // Timeout
  // withCredentials: true, // Check cross-site Access-Control
};

const _axios = axios.create(config);

_axios.interceptors.request.use(
  function (config) {
    let token = localStorage.getItem("token");

    if (token) {
      if (jwtDecode(token).exp >= Date.now() / 1000) {
        config.headers['Authorization'] = 'Bearer ' + token;
      }
    } else {
      alert("Token no AUTORIZADO");
      //window.location = process.env.VUE_APP_PORTAL_URL;
      router.push({ name: "about" });
    }
    // Do something before request is sent
    return config;
  },
  error => Promise.reject(error)
);

// Add a response interceptor
_axios.interceptors.response.use(
  response => response,
  function (error) {
    let token = localStorage.getItem('token');

    const tokenDecoded = jwtDecode(token);
    var timeIsOut = (tokenDecoded.exp < Date.now() / 1000);
    if (timeIsOut) {
      if (error.response !== undefined) {

        if (error.response.status !== 401) {
          return Promise.reject(error);
        }
        else if (error.response.status === 401) {
          store.dispatch("setNeedReload", false);
          alert("Token no AUTORIZADO");

          if (window.location.href.includes('Expired') == false)
            router.push({ name: "login" });          
        }
      }
      else {
        //alert('API IS NOT RUNING');
      }
    } else {
      if (error.response !== undefined) {

        if (error.response.status === 400) {
          alert("Error> Peticion Erronea (400): " + error.response.data.Message);
        } else
          if (error.response.status === 404) {
            alert("Error> No Data (404): " + error.response.data);
          }
      }
    }
    // Do something with response error
    return Promise.reject(error);
  }
);

Plugin.install = function(Vue) {
  Vue.axios = _axios;
  window.axios = _axios;
  Object.defineProperties(Vue.prototype, {
    axios: {
      get() {
        return _axios;
      }
    },
    $axios: {
      get() {
        return _axios;
      }
    },
  });
};

Vue.use(Plugin)

export default Plugin;
