<script setup lang="ts">
import Card from "primevue/card";
import Tag from "primevue/tag";
import type { Ticket } from "@/models/ticket";

const props = defineProps<{ ticket: Ticket }>();

function formatDate(dateStr: string): string {
  return new Date(dateStr).toLocaleDateString(undefined, {
    year: "numeric",
    month: "short",
    day: "numeric",
  });
}

const statusLabel = (status: 0 | 1) => (status === 1 ? "Open" : "Closed");
const statusSeverity = (status: 0 | 1) =>
  status === 1 ? "success" : "secondary";
</script>

<template>
  <Card class="ticket-card">
    <template #title>
      {{ ticket.title }}
    </template>
    <template #subtitle> Created {{ formatDate(ticket.createdAt) }} </template>
    <template #footer>
      <Tag
        :value="statusLabel(ticket.status)"
        :severity="statusSeverity(ticket.status)"
      />
    </template>
  </Card>
</template>

<style scoped>
.ticket-card {
  width: 100%;
}
</style>
