import { IPageRepository } from "../../ports/page-repository";
import { Page } from "../../../domain/entities/page";

export class GetPagesUseCase {
  constructor(private pageRepository: IPageRepository) {}

  async execute(): Promise<Page[]> {
    return this.pageRepository.getAll();
  }
}
