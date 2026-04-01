import axios from "axios";
import type { ITicketsRepository } from "@/data/repositories/Interfaces/ITicketsRepository";
import type { Ticket } from "@/models/ticket";

const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

class TicketsRepository implements ITicketsRepository {
  async getTickets(): Promise<Ticket[]> {
    const response = await axios.get<Ticket[]>(`${apiBaseUrl}/tickets`);
    return response.data;
  }
}

export default TicketsRepository;
