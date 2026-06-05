import { useState, useEffect } from "react";
import { Workspace } from "@/domain/entities/workspace";
import { GetWorkspacesUseCase } from "@/application/use-cases/workspace/get-workspaces";
import { WorkspaceRepositoryImpl } from "@/infrastructure/repositories/workspace-repository.impl";

export function useWorkspaces() {
  const [workspaces, setWorkspaces] = useState<Workspace[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    const fetchWorkspaces = async () => {
      try {
        const repository = new WorkspaceRepositoryImpl();
        const useCase = new GetWorkspacesUseCase(repository);
        const data = await useCase.execute();
        setWorkspaces(data);
      } catch (err) {
        setError(
          err instanceof Error ? err : new Error("Failed to fetch workspaces")
        );
      } finally {
        setLoading(false);
      }
    };

    fetchWorkspaces();
  }, []);

  return { workspaces, loading, error };
}
