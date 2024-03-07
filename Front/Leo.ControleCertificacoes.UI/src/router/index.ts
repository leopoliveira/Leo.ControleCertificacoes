import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'

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
      component: () => import('@/views/Employee/EmployeeView.vue'),
      /*children: [
        {
          path: 'create',
          component: () => import('@/views/EmployeeCreateView.vue'),
        },
        {
          path: 'edit',
          component: () => import('@/views/EmployeeEditView.vue'),
        },
        {
          path: 'delete',
          component: () => import('@/views/EmployeeDeleteView.vue'),
        },
      ]*/
    },
    {
      path: '/certified/:code',
      name: 'certified',
      component: () => import('@/views/Certified/CertifiedView.vue'),
      children: [
        /*{
          path: 'create',
          component: () => import('@/views/CertifiedCreateView.vue'),
        },*/
        {
          path: 'edit',
          name: 'certified-edit',
          component: () => import('@/views/Certified/CertifiedEditView.vue'),
        },
        {
          path: 'delete',
          component: () => import('@/views/Certified/CertifiedDeleteView.vue'),
        }
      ]
    }
  ]
})

export default router
