import { Workspace } from './Workspace';
import { User } from './User';
import { Role } from './Role';

export interface WorkspaceUser {
  id: string;
  workspace_id: string;
  user_id: string;
  role: string;
  
  // Relations optionnelles provenant de l'API
  workspace?: Workspace;
  user?: User;
  roleDetails?: Role;
}
