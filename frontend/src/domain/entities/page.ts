export interface Page {
    id: number;
    title: string;
    content: string;
    icon: string | null;
    parentPageId: number | null;
    workspaceId: number;
    createdById: number;
    createdAt: string;
    updatedAt: string;
}

export interface CreatePageDto {
    title: string;
    content: string;
    icon?: string;
    parentPageId?: number;
    workspaceId: number;
}

export interface UpdatePageDto {
    id: number;
    title: string;
    content: string;
    icon?: string;
    parentPageId?: number;
}