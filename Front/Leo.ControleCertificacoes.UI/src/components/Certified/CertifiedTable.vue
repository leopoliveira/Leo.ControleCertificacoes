<script lang="ts">
import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import { GetByCode } from "@/services/Certified/CertifiedService";

import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Button from "primevue/button";

import { useRoute } from "vue-router";
import { ref } from "vue";

import { format } from "date-fns";
import { ptBR } from "date-fns/locale/pt-BR";

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
        field: "description",
        header: "Descrição",
      },
    ];
  },
  async mounted() {
    this.certifieds = await GetByCode(this.routeParamCode as string);
  },
  components: {
    DataTable,
    Column,
    Button,
  },
  methods: {
    formatDate(dateString: string, formatString: string) {
      return format(new Date(dateString), formatString, {
        locale: ptBR,
      });
    },
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
      <Column
        field="expiration"
        header="Data de Vencimento">
        <template #body="slotProps">{{
          formatDate(
            slotProps.data.expiration,
            "dd 'de' MMMM 'de' yyyy"
          )
        }}</template>
      </Column>
      <Column header="Ações">
        <template #body="slotProps">
          <div class="flex gap-2">
            <router-link
              :to="'/certified/edit/' + slotProps.data.code">
              <Button
                label="Editar"
                severity="info"
                outlined />
            </router-link>
            <router-link
              :to="'/certified/delete/' + slotProps.data.code">
              <Button
                label="Excluir"
                severity="danger"
                outlined />
            </router-link>
          </div>
        </template>
      </Column>
    </DataTable>
  </div>
</template>
