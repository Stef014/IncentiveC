<script setup lang="ts">
import { reactive } from "vue";
import Card from "primevue/card";
import InputText from "primevue/inputtext";
import Textarea from "primevue/textarea";
import Button from "primevue/button";
import { FloatLabel } from "primevue";

const emit = defineEmits<{ submit: [title: string, description: string] }>();

const form = reactive({ title: "", description: "" });

function handleSubmit() {
  if (!form.title.trim() || !form.description.trim()) return;
  emit("submit", form.title.trim(), form.description.trim());
  form.title = "";
  form.description = "";
}
</script>

<template>
  <Card class="create-ticket-card">
    <template #title>New Ticket</template>
    <template #content>
      <form class="create-ticket-form" @submit.prevent="handleSubmit">
        <FloatLabel>
          <InputText id="title" v-model="form.title" class="w-full" required />
          <label for="title">Title</label>
        </FloatLabel>
        <FloatLabel>
          <Textarea
            id="description"
            v-model="form.description"
            class="w-full"
            rows="5"
            auto-resize
            required
          />
          <label for="description">Description</label>
        </FloatLabel>
        <div class="form-actions">
          <Button type="submit" label="Create Ticket" icon="pi pi-plus" />
        </div>
      </form>
    </template>
  </Card>
</template>

<style scoped>
.create-ticket-card {
  width: 100%;
}

:deep(.p-card-body) {
  padding: 1.5rem 2rem;
}

.create-ticket-form {
  display: flex;
  flex-direction: column;
  gap: 2rem;
}

:deep(.p-inputtext),
:deep(.p-textarea) {
  width: 100%;
  font-size: 1rem;
  padding: 0.75rem 1rem;
}

:deep(.p-textarea) {
  min-height: 200px;
}

.form-actions {
  display: flex;
  justify-content: flex-end;
}
</style>
