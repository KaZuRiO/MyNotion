import {
  Workspace,
  CreateWorkspaceDto,
  UpdateWorkspaceDto,
} from "../../domain/entities/workspace";

export interface IWorkspaceRepository {
  getAll(): Promise<Workspace[]>;
  getById(id: number): Promise<Workspace>;
  create(data: CreateWorkspaceDto): Promise<Workspace>;
  update(id: number, data: UpdateWorkspaceDto): Promise<Workspace>;
  delete(id: number): Promise<void>;
}
