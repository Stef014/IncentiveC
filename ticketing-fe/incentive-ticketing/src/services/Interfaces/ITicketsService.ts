import type { Ticket } from "@/models/ticket";

interface ITicketsService {
  getTickets(): Promise<Ticket[] | null>;
}

export type { ITicketsService };
