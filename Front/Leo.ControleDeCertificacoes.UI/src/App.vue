<script lang="ts">
import { RouterLink } from "vue-router";

export default {
   components: {
      RouterLink
   }
};
</script>

<template>
   <header>
      <div class="p-3 text-xl font-bold">
         <nav class="flex gap-5">
            <RouterLink to="/">Home</RouterLink>
            <RouterLink to="/funcionario">Funcionários</RouterLink>
            <RouterLink to="/certificado">Certificados</RouterLink>
         </nav>
      </div>
   </header>
</template>

<style scoped></style>
