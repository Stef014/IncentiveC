<script setup lang="ts">
import DataView from "primevue/dataview";
import TicketListItem from "@/components/TicketListItem.vue";
import type { Ticket } from "@/models/ticket";

defineProps<{ tickets: Ticket[] }>();
</script>

<template>
  <DataView :value="tickets" data-key="id">
    <template #list="{ items }">
      <div class="ticket-list">
        <TicketListItem
          v-for="ticket in items"
          :key="ticket.id"
          :ticket="ticket"
        />
      </div>
    </template>
    <template #empty>
      <p class="empty-message">No tickets found.</p>
    </template>
  </DataView>
</template>

<style scoped>
:deep(.p-dataview-content) {
  max-height: 70vh;
  overflow-y: auto;
}

.ticket-list {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  padding: 1rem;
}

.empty-message {
  text-align: center;
  padding: 2rem;
  color: var(--p-text-muted-color);
}
</style>
