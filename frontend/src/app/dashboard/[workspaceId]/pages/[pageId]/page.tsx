export default function PageContent({
  params,
}: {
  params: { workspaceId: string; pageId: string };
}) {
  return (
    <div className="flex flex-1 flex-col gap-4">
      <div className="mx-auto h-24 w-full max-w-3xl rounded-xl bg-muted/50 flex items-center justify-center">
        <h1 className="text-2xl font-bold">
          Page {params.pageId} (Workspace {params.workspaceId})
        </h1>
      </div>
      <div className="mx-auto h-full w-full max-w-3xl rounded-xl bg-muted/50 p-8">
        <p className="text-muted-foreground">
          This is the content of the page.
        </p>
      </div>
    </div>
  );
}
