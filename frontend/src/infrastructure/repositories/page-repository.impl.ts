import { IPageRepository } from "../../application/ports/page-repository";
import { Page, CreatePageDto, UpdatePageDto } from "../../domain/entities/page";
import { apiFetch } from "../api/http-client";

export class PageRepositoryImpl implements IPageRepository {
  async getAll(): Promise<Page[]> {
    return apiFetch<Page[]>("/Pages");
  }

  async getById(id: number): Promise<Page> {
    return apiFetch<Page>(`/Pages/${id}`);
  }

  async getByWorkspaceId(workspaceId: number): Promise<Page[]> {
    return apiFetch<Page[]>(`/Workspaces/${workspaceId}/Pages`);
  }

  async create(data: CreatePageDto): Promise<Page> {
    return apiFetch<Page>("/Pages", {
      method: "POST",
      body: JSON.stringify(data),
    });
  }

  async update(id: number, data: UpdatePageDto): Promise<Page> {
    return apiFetch<Page>(`/Pages/${id}`, {
      method: "PUT",
      body: JSON.stringify(data),
    });
  }

  async delete(id: number): Promise<void> {
    return apiFetch<void>(`/Pages/${id}`, {
      method: "DELETE",
    });
  }
}
