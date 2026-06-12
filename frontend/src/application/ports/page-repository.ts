import {
    Page,
    CreatePageDto,
    UpdatePageDto,
} from "../../domain/entities/page";

export interface IPageRepository { 
    getAll(): Promise<Page[]>;
    getById(id: number): Promise<Page>;
    getByWorkspaceId(workspaceId: number): Promise<Page[]>;
    create(data: CreatePageDto): Promise<Page>;
    update(id: number, data: UpdatePageDto): Promise<Page>;
    delete(id: number): Promise<void>;
}