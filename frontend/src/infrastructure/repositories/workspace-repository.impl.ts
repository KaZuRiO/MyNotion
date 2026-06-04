import { IWorkspaceRepository } from "../../application/ports/workspace-repository";
import {
  Workspace,
  CreateWorkspaceDto,
  UpdateWorkspaceDto,
} from "../../domain/entities/workspace";
import { apiFetch } from "../api/http-client";

export class WorkspaceRepositoryImpl implements IWorkspaceRepository {
  async getAll(): Promise<Workspace[]> {
    return apiFetch<Workspace[]>("/Workspaces");
  }

  async getById(id: number): Promise<Workspace> {
    return apiFetch<Workspace>(`/Workspaces/${id}`);
  }

  async create(data: CreateWorkspaceDto): Promise<Workspace> {
    return apiFetch<Workspace>("/Workspaces", {
      method: "POST",
      body: JSON.stringify(data),
    });
  }

  async update(id: number, data: UpdateWorkspaceDto): Promise<Workspace> {
    return apiFetch<Workspace>(`/Workspaces/${id}`, {
      method: "PUT",
      body: JSON.stringify(data),
    });
  }

  async delete(id: number): Promise<void> {
    return apiFetch<void>(`/Workspaces/${id}`, {
      method: "DELETE",
    });
  }
}
