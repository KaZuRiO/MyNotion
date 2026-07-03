import { IWorkspaceRepository } from "../../ports/workspace-repository";
import { Workspace } from "../../../domain/entities/workspace";

export class GetWorkspacesUseCase {
  constructor(private workspaceRepository: IWorkspaceRepository) {}

  async execute(): Promise<Workspace[]> {
    return this.workspaceRepository.getAll();
  }
}
