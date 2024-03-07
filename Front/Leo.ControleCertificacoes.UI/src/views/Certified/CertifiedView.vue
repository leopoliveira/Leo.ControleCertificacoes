<script lang="ts">
import { RouterView } from "vue-router";

import CertifiedTable from "@/components/Certified/CertifiedTable.vue";

export default {
  components: {
    CertifiedTable,
    RouterView,
  },
};
</script>

<template>
  <div class="">
    <h1>Certificados</h1>
    <CertifiedTable />
  </div>
  <RouterView />
</template>

<style scoped></style>
