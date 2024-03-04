<script lang="ts">
import DataTable from "primevue/datatable";
import Column from "primevue/column";

export default {
  components: {
    DataTable,
    Column,
  },
};
</script>

<template>
  <div class="card">
    <DataTable
      :value="products"
      tableStyle="min-width: 50rem">
      <Column
        field="code"
        header="Code"></Column>
      <Column
        field="name"
        header="Name"></Column>
      <Column
        field="category"
        header="Category"></Column>
      <Column
        field="quantity"
        header="Quantity"></Column>
    </DataTable>
  </div>
</template>

<style scoped></style>
