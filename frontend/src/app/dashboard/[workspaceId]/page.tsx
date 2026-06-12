export default function WorkspacePage({
  params,
}: {
  params: { workspaceId: string };
}) {
  return (
    <div className="flex flex-1 flex-col gap-4">
      <div className="mx-auto h-24 w-full max-w-3xl rounded-xl bg-muted/50 flex items-center justify-center">
        <h1 className="text-2xl font-bold">Workspace {params.workspaceId}</h1>
      </div>
      <div className="mx-auto h-full w-full max-w-3xl rounded-xl bg-muted/50" />
    </div>
  );
}
