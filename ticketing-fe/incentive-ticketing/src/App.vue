<script setup lang="ts">
import { ref, onMounted } from 'vue'
import TicketList from "@/components/TicketList.vue";
import TicketsService from "@/services/TicketsService";
import TicketsRepository from "@/data/repositories/TicketsRepository";
import type { Ticket } from "@/models/ticket";

const ticketsService = new TicketsService(new TicketsRepository())

const tickets = ref<Ticket[]>([])

onMounted(async () => {
  tickets.value = await ticketsService.getTickets() ?? []
})
</script>

<template>
  <main class="app-container">
    <h1 class="app-title">Support Tickets</h1>
    <TicketList :tickets="tickets" />
  </main>
</template>

<style scoped>
.app-container {
  max-width: 800px;
  margin: 0 auto;
  padding: 2rem 1rem;
}

.app-title {
  margin-bottom: 1.5rem;
}
</style>
