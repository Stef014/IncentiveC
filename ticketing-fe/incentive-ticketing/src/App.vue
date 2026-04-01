<script setup lang="ts">
import TicketList from "@/components/TicketList.vue";
import { tickets } from "@/data/tickets";
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
