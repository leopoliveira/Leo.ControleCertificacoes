<script lang="ts">
import { RouterLink } from "vue-router";
import Cu from "./components/Cu.vue";

export default {
   components: {
      RouterLink,
      Cu
   }
};
</script>

<template>
   <header>
      <div class="wrapper">
         <nav>
            <RouterLink to="/">Home</RouterLink>
            <RouterLink to="/about">About</RouterLink>
            <Cu />
         </nav>
      </div>
   </header>
</template>

<style scoped></style>
