import { WorkspaceUser } from './WorkspaceUser';
import { Page } from './Page';
import { Workspace } from './Workspace';

export interface User {
  id: string;
  username: string;
  email: string;
  avatar_url?: string;
  create_at: string;
  update_at: string;
  is_active: boolean;

  // Relations optionnelles provenant de l'API
  workspaceUsers?: WorkspaceUser[];
  createdPages?: Page[];
  ownedWorkspaces?: Workspace[];
}
