import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/employee',
      name: 'employee',
      component: () => import('../views/EmployeeView.vue')
    },
    {
      path: '/certified',
      name: 'certified',
      component: () => import('../views/CertifiedView.vue')
    }
  ]
})

export default router
