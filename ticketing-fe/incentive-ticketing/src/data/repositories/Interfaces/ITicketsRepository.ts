import type { Ticket } from "@/models/ticket";

interface ITicketsRepository {
  getTickets(): Promise<Ticket[] | null>;
}

export type { ITicketsRepository };
