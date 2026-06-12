import { AppSidebar } from "@/presentation/components/features/app-sidebar";
import { NavActions } from "@/presentation/components/features/nav-actions";
import { DynamicBreadcrumb } from "@/presentation/components/features/dynamic-breadcrumb";
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbList,
} from "@/presentation/components/ui/breadcrumb";
import { Separator } from "@/presentation/components/ui/separator";
import {
  SidebarInset,
  SidebarProvider,
  SidebarTrigger,
} from "@/presentation/components/ui/sidebar";

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <SidebarProvider>
      <AppSidebar />
      <SidebarInset>
        <header className="flex h-14 shrink-0 items-center gap-2">
          <div className="flex flex-1 items-center gap-2 px-3">
            <SidebarTrigger />
            <Separator
              orientation="vertical"
              className="mr-2 data-vertical:h-4 data-vertical:self-auto"
            />
            <Breadcrumb>
              <BreadcrumbList>
                <BreadcrumbItem>
                  <DynamicBreadcrumb />
                </BreadcrumbItem>
              </BreadcrumbList>
            </Breadcrumb>
          </div>
          <div className="ml-auto px-3">
            <NavActions />
          </div>
        </header>
        <main className="flex flex-1 flex-col gap-4 px-4 py-10">
          {children}
        </main>
      </SidebarInset>
    </SidebarProvider>
  );
}
