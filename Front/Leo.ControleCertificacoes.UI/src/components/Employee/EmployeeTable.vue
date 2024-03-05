<script lang="ts">
import type { EmployeeReadType } from "../../types/Employee/EmployeeReadType";

import { GetAllEmployees } from "../../services/Employee/EmployeeService";

import DataTable from "primevue/datatable";
import Column from "primevue/column";

export default {
  data() {
    return {
      columns: [] as any[],
      employees: [] as EmployeeReadType[],
    };
  },
  created() {
    this.columns = [
      {
        field: "code",
        header: "Cód.",
      },
      {
        field: "name",
        header: "Nome",
      },
      {
        field: "department",
        header: "Departamento",
      },
      {
        field: "numberOfCertifieds",
        header: "Qtde. Certificados",
      },
    ];
  },
  async mounted() {
    this.employees = await GetAllEmployees();
  },
  components: {
    DataTable,
    Column,
  },
};
</script>

<template>
  <div class="">
    <DataTable
      :value="employees"
      stripedRows
      paginator
      :rows="25"
      :tableStyle="{ minWidth: '50rem' }">
      <Column
        v-for="col of columns"
        :key="col.field"
        :field="col.field"
        :header="col.header"></Column>
    </DataTable>
  </div>
</template>

<style scoped></style>
