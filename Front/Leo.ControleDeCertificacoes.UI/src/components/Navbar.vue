<script lang="ts">
import Menubar from "primevue/menuBar";
import type { MenuItem } from "primevue/menuitem";
import "primeicons/primeicons.css";

export default {
  data() {
    return {
      items: [
        {
          label: "Funcionários",
          icon: "pi pi-users",
        },
        {
          label: "Certificações",
          icon: "pi pi-file",
        },
      ] as MenuItem[],
    };
  },
  components: {
    Menubar,
  },
};
</script>

<template>
  <div class="card">
    <Menubar
      :model="items"
      :breakpoint="'400px'" />
  </div>
</template>

<style scoped>
.card {
  background: var(--surface-card);
  padding: 2rem;
  border-radius: 10px;
  margin-bottom: 1rem;
}
</style>
