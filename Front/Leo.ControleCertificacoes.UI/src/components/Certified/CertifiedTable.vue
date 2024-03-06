<script lang="ts">
import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import { GetByCode } from "@/services/Certified/CertifiedService";

import DataTable from "primevue/datatable";
import Column from "primevue/column";
import { useRoute } from "vue-router";
import { ref } from "vue";

export default {
  setup() {
    const route = useRoute();
    let routeParamCode = ref(route.params.code);

    return { routeParamCode };
  },
  data() {
    return {
      columns: [] as any[],
      certifieds: [] as CertifiedReadType[],
      code: "0" as string,
    };
  },
  create() {
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
        field: "description",
        header: "Descrição",
      },
    ];
    this.code = this.routeParamCode as string;
  },
  async mount() {
    this.certifieds = await GetByCode(this.code);
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
      :value="certifieds"
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
