import Vue from 'vue'
import VueRouter from 'vue-router'
import EmployeeDetail from '../views/employee/EmployeeView';
import CustomerDetail from '../views/customer/CustomerView';
import Home from '../components/layout/HelloWorld.vue';

Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    routes: [
        { path: '/danh-muc/nhan-vien', name: 'EmployeeDetail', component: EmployeeDetail },
        { path: '/danh-muc/khach-hang', name: 'CustomerDetail', component: CustomerDetail },
        { path: '/', name: 'Home', component: Home }
    ]
})

export default router