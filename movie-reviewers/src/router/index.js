import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import store from '../store'


import Login from '../components/Login.vue'

Vue.use(VueRouter)

const routes = [{
    path: '/',
    name: 'home',
    component: Home,
    meta: {
      administrador: true,
      user: true,
    }
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import( /* webpackChunkName: "about" */ '../views/About.vue'),
    meta: {
      libre: true
    }
  },
  {
    path: '/login',
    name: 'login',
    component: Login,
    meta: {
      libre: true
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})


router.beforeEach((to, from, next) => {

  console.log(store.state.usuario);
  if (to.matched.some(record => record.meta.libre)) {
    next()
  } else if (store.state.usuario && store.state.usuario.role == 'Admin') {
    if (to.matched.some(record => record.meta.administrador)) {
      next()
    }
  } else if (store.state.usuario && store.state.usuario.role == 'User') {
    if (to.matched.some(record => record.meta.user)) {
      next()
    }
  } else {
    next({
      name: 'login'
    })
  }
});

export default router