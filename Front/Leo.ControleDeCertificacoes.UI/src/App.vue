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
      <div class="wrapper">
         <nav>
            <RouterLink to="/">Home</RouterLink>
            <RouterLink to="/about">About</RouterLink>
         </nav>
      </div>
   </header>
</template>

<style scoped></style>
