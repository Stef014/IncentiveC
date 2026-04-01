import type { ITicketsService } from "@/services/Interfaces/ITicketsService";
import type { ITicketsRepository } from "@/data/repositories/Interfaces/ITicketsRepository";
import type { Ticket } from "@/models/ticket";

class TicketsService implements ITicketsService {
  private ticketsRepository: ITicketsRepository;

  constructor(ticketsRepository: ITicketsRepository) {
    this.ticketsRepository = ticketsRepository;
  }
  async createTicket(title: string, description: string): Promise<Ticket> {
    try {
      return await this.ticketsRepository.createTicket(title, description);
    } catch (error) {
      console.error("Error creating ticket:", error);
      throw error;
    }
  }

  async getTickets(): Promise<Ticket[] | null> {
    try {
      return await this.ticketsRepository.getTickets();
    } catch (error) {
      console.error("Error fetching tickets:", error);
      throw error;
    }
  }
}

export default TicketsService;
