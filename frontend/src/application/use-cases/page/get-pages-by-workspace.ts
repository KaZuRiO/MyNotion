import { IPageRepository } from "../../ports/page-repository";
import { Page } from "../../../domain/entities/page";

export class GetPagesByWorkspaceUseCase {
  constructor(private pageRepository: IPageRepository) {}

  async execute(workspaceId: number): Promise<Page[]> {
    return this.pageRepository.getByWorkspaceId(workspaceId);
  }
}
