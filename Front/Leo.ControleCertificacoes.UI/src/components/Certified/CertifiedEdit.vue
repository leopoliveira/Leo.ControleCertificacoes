<script lang="ts">
import Dialog from "primevue/dialog";
import Avatar from "primevue/avatar";
import InputText from "primevue/inputtext";
import Button from "primevue/button";

export default {
  data() {
    return {
      visible: false,
    };
  },
  props: {
    show: {
      type: Boolean,
      required: true,
    },
  },
  watch: {
    show(newValue) {
      this.visible = newValue;
    },
  },
  components: {
    Dialog,
    Avatar,
    InputText,
    Button,
  },
  emits: ["closed"],
};
</script>

<template>
  <Dialog
    v-model:visible="visible"
    modal
    header="Edit Profile"
    :closable="false">
    <template #header>
      <div
        class="inline-flex align-items-center justify-content-center gap-2">
        <Avatar
          image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png"
          shape="circle" />
        <span class="font-bold white-space-nowrap">Amy Elsner</span>
      </div>
    </template>
    <span class="p-text-secondary block mb-5"
      >Update your information.</span
    >
    <div class="flex align-items-center gap-3 mb-3">
      <label
        for="username"
        class="font-semibold w-6rem"
        >Username</label
      >
      <InputText
        id="username"
        class="flex-auto"
        autocomplete="off" />
    </div>
    <div class="flex align-items-center gap-3 mb-2">
      <label
        for="email"
        class="font-semibold w-6rem"
        >Email</label
      >
      <InputText
        id="email"
        class="flex-auto"
        autocomplete="off" />
    </div>
    <template #footer>
      <Button
        label="Cancelar"
        text
        severity="secondary"
        @click="$emit('closed')"
        autofocus />
      <Button
        label="Salvar"
        outlined
        severity="secondary"
        autofocus />
    </template>
  </Dialog>
</template>
