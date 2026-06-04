import { User } from './User';
import { WorkspaceUser } from './WorkspaceUser';
import { Page } from './Page';

export interface Workspace {
  id: string;
  name: string;
  description?: string;
  owner_id: string;
  create_at: string;
  update_at: string;

  // Relations optionnelles provenant de l'API
  owner?: User;
  workspaceUsers?: WorkspaceUser[];
  pages?: Page[];
}
