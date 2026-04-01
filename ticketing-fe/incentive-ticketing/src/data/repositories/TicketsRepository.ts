import axios from "axios";
import type { ITicketsRepository } from "@/data/repositories/Interfaces/ITicketsRepository";
import type { Ticket } from "@/models/ticket";

const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

class TicketsRepository implements ITicketsRepository {
  async createTicket(title: string, description: string): Promise<Ticket> {
    axios.defaults.headers.post["Content-Type"] = "application/json";
    const response = await axios.post<Ticket>(`${apiBaseUrl}/tickets`, {
      title,
      description,
    });
    return response.data;
  }
  async getTickets(): Promise<Ticket[] | null> {
    const response = await axios.get<Ticket[]>(`${apiBaseUrl}/tickets`);
    return response.data;
  }

  async updateTicketStatus(id: string, status: boolean): Promise<Ticket> {
    console.log(`Updating ticket ${id} status to ${status}`);
    const response = await axios.patch<Ticket>(
      `${apiBaseUrl}/tickets/${id}/status`,
      status,
      {
        headers: { "Content-Type": "application/json" },
      },
    );
    return response.data;
  }
}

export default TicketsRepository;
