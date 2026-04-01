import type { Ticket } from "@/models/ticket";

interface ITicketsRepository {
  createTicket(title: string, description: string): Promise<Ticket>;
  getTickets(): Promise<Ticket[] | null>;
}

export type { ITicketsRepository };
