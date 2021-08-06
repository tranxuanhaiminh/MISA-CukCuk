import Vue from 'vue'
import App from './App.vue'
// import VueRouter from 'vue-router'
// import axios from 'vue-axios'
// import VueAxios from 'vue-axios'

// import EmployeeList from './views/dictionary/employee/EmployeeList.vue'
// 
// Vue.use(VueRouter)
// const Foo = {name:'foo', template: '<div>foo</div>'}
// 
// const routers = [
//   {path: '/employee', name: 'EmployeeList', component: EmployeeList},
//   {path: '/customer', name: 'CustomerList', component: CustomerList}
// ]
// 
// const router = new VueRouter({
//   mode: 'history',
//   base: process.env.BASE_URL,
//   routers
// })

Vue.config.productionTip = false
// Vue.use(VueAxios, axios)

new Vue({
  // router,
  render: h => h(App)
}).$mount('#app')
