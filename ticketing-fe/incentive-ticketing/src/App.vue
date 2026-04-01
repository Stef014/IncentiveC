<script setup lang="ts">
import { ref, watch, onMounted } from "vue";
import TicketList from "@/components/TicketList.vue";
import CreateTicket from "@/components/CreateTicket.vue";
import TicketsService from "@/services/TicketsService";
import TicketsRepository from "@/data/repositories/TicketsRepository";
import type { Ticket } from "@/models/ticket";

const ticketsService = new TicketsService(new TicketsRepository());

const tickets = ref<Ticket[]>([]);
const ticketCount = ref(0);

watch(
  tickets,
  (updated) => {
    ticketCount.value = updated.length;
  },
  { deep: true },
);

onMounted(async () => {
  tickets.value = (await ticketsService.getTickets()) ?? [];
});

async function onTicketCreated(title: string, description: string) {
  const newTicket: Ticket = {
    id: crypto.randomUUID(),
    title,
    description,
    status: 1,
    createdAt: new Date().toISOString(),
  };
  tickets.value = [newTicket, ...tickets.value];

  await ticketsService.createTicket(title, description);
}
</script>

<template>
  <main class="app-container">
    <h1 class="app-title">Support Tickets</h1>
    <div class="app-layout">
      <div class="create-panel">
        <CreateTicket @submit="onTicketCreated" />
      </div>
      <div class="list-panel">
        <p class="ticket-count">
          {{ ticketCount }} ticket{{ ticketCount !== 1 ? "s" : "" }}
        </p>
        <TicketList :tickets="tickets" />
      </div>
    </div>
  </main>
</template>

<style scoped>
.app-container {
  max-width: 1400px;
  margin: 0 auto;
  padding: 2rem 1rem;
}

.app-title {
  margin-bottom: 1.5rem;
}

.app-layout {
  display: flex;
  gap: 1.5rem;
  align-items: flex-start;
}

.create-panel {
  flex: 7;
}

.list-panel {
  flex: 3;
}

.ticket-count {
  font-size: 0.9rem;
  color: var(--p-text-muted-color);
  margin-bottom: 0.75rem;
}
</style>
