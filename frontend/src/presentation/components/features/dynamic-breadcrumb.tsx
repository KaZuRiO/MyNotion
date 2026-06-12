"use client";

import { useParams } from "next/navigation";
import { useWorkspaces } from "@/presentation/hooks/use-workspaces";
import { BreadcrumbPage } from "@/presentation/components/ui/breadcrumb";

export function DynamicBreadcrumb() {
  const params = useParams();
  const { workspaces, loading } = useWorkspaces();

  const workspaceId = params?.workspaceId as string;
  
  if (loading) {
    return <BreadcrumbPage className="line-clamp-1">Loading...</BreadcrumbPage>;
  }

  const workspace = workspaces.find((w) => w.id.toString() === workspaceId);

  return (
    <BreadcrumbPage className="line-clamp-1">
      {workspace ? workspace.name : "Dashboard"}
    </BreadcrumbPage>
  );
}
