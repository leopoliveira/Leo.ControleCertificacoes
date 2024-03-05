import "./assets/main.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import PrimeVue from "primevue/config";
import Lara from "./presets/lara";
import Axios from "axios";

const app = createApp(App);

app.use(PrimeVue, { unstyled: true, pt: Lara });
app.use(router)

app.config.globalProperties.$axios = Axios;
Axios.defaults.baseURL = import.meta.env.VITE_API_BASE_DEV_URL;

app.mount("#app");
