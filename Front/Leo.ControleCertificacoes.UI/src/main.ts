import "./assets/main.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import PrimeVue from "primevue/config";
import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice';
import Lara from "./presets/lara";

const app = createApp(App);

app.use(PrimeVue, { unstyled: true, pt: Lara })
  .use(ConfirmationService)
  .use(ToastService)
  .use(router)

app.mount("#app");
