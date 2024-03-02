<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <div class="">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/funcionario">Funcionários</RouterLink>
        <RouterLink to="/certificado">Certificados</RouterLink>
      </nav>
    </div>
  </header>

  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
