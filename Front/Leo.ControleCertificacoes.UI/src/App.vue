<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <div class="">
      <nav class="flex w-100 gap-2 m-2 p-2">
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/employee">Funcionários</RouterLink>
      </nav>
    </div>
  </header>

  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
