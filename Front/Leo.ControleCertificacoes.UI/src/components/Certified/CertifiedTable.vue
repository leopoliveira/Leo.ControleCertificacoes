<script lang="ts">
import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import {
  GetByCode,
  Delete,
} from "@/services/Certified/CertifiedService";

import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Button from "primevue/button";
import ConfirmDialog from "primevue/confirmdialog";
import Toast from "primevue/toast";

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
    ConfirmDialog,
    Toast,
  },
  methods: {
    formatDate(dateString: string, formatString: string) {
      return format(new Date(dateString), formatString, {
        locale: ptBR,
      });
    },
    deleteCertified(id: string, name: string) {
      this.$confirm.require({
        message: `Tem certeza que deseja apagar o certificado ${name} ?`,
        header: "Atenção!",
        icon: "pi pi-info-circle",
        rejectLabel: "Cancelar",
        rejectClass: "bg-stone-600 border-inherit hover:bg-stone-600",
        acceptLabel: "Excluir",
        acceptClass: "bg-rose-500 border-inherit hover:bg-rose-600",
        accept: () => {
          Delete(id)
            .then(() => {
              this.$toast.add({
                severity: "success",
                summary: "Sucesso!",
                detail: `O certificado ${name} foi excluído.`,
                life: 3000,
              });
            })
            .catch(() =>
              this.$toast.add({
                severity: "error",
                summary: "Erro!",
                detail: "Algo errado ocorreu.",
                life: 3000,
              })
            )
            .finally(async () => {
              this.certifieds = await GetByCode(
                this.routeParamCode as string
              );
            });
        },
      });
    },
  },
};
</script>

<template>
  <Toast />
  <ConfirmDialog></ConfirmDialog>
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
            <Button
              label="Editar"
              severity="info"
              outlined />
            <Button
              label="Excluir"
              severity="danger"
              outlined
              @click="
                deleteCertified(
                  slotProps.data.id,
                  slotProps.data.name
                )
              " />
          </div>
        </template>
      </Column>
    </DataTable>
  </div>
</template>
