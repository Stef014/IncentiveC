<script setup lang="ts">
import { ref } from 'vue'
import Card from "primevue/card";
import Tag from "primevue/tag";
import ToggleSwitch from 'primevue/toggleswitch';
import TicketsService from '@/services/TicketsService';
import TicketsRepository from '@/data/repositories/TicketsRepository';
import type { Ticket } from "@/models/ticket";

const props = defineProps<{ ticket: Ticket }>();
const emit = defineEmits<{ statusChanged: [ticket: Ticket] }>()

const ticketsService = new TicketsService(new TicketsRepository())

// status 0 = Open, status 1 = Closed; toggle is true when Closed
const isClosed = ref(props.ticket.status === 1)

async function toggleStatus() {
  const updated = await ticketsService.updateTicketStatus(props.ticket.id, isClosed.value)
  emit('statusChanged', updated)
}

function formatDate(dateStr: string): string {
  return new Date(dateStr).toLocaleDateString(undefined, {
    year: "numeric",
    month: "short",
    day: "numeric",
  });
}

const statusLabel = (status: 0 | 1) => (status === 1 ? "Closed" : "Open");
const statusSeverity = (status: 0 | 1) =>
  status === 1 ? "secondary" : "success";
</script>

<template>
  <Card class="ticket-card">
    <template #title>
      {{ ticket.title }}
    </template>
    <template #subtitle> Created {{ formatDate(ticket.createdAt) }} </template>
    <template #footer>
      <div class="ticket-footer">
        <Tag
          :value="statusLabel(ticket.status)"
          :severity="statusSeverity(ticket.status)"
        />
        <div class="toggle-wrapper">
          <label class="toggle-label">{{ isClosed ? 'Close' : 'Open' }}</label>
          <ToggleSwitch v-model="isClosed" @change="toggleStatus" />
        </div>
      </div>
    </template>
  </Card>
</template>

<style scoped>
.ticket-card {
  width: 100%;
}

.ticket-footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.toggle-wrapper {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.toggle-label {
  font-size: 0.85rem;
  color: var(--p-text-muted-color);
}
</style>
