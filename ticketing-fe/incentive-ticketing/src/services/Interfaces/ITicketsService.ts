import type { Ticket } from "@/models/ticket";

interface ITicketsService {
  getTickets(): Promise<Ticket[] | null>;
  createTicket(title: string, description: string): Promise<Ticket>;
  updateTicketStatus(id: string, status: boolean): Promise<Ticket>;
}

export type { ITicketsService };
