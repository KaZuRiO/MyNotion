"use client";

import * as React from "react";

import { NavFavorites } from "@/presentation/components/features/nav-favorites";
import { NavMain } from "@/presentation/components/features/nav-main";
import { NavSecondary } from "@/presentation/components/features/nav-secondary";
import { NavWorkspaces } from "@/presentation/components/features/nav-workspaces";
import { TeamSwitcher } from "@/presentation/components/features/team-switcher";
import {
  Sidebar,
  SidebarContent,
  SidebarHeader,
  SidebarRail,
} from "@/presentation/components/ui/sidebar";
import {
  TerminalIcon,
  AudioLinesIcon,
  SearchIcon,
  SparklesIcon,
  HomeIcon,
  InboxIcon,
  CalendarIcon,
  Settings2Icon,
  BlocksIcon,
  Trash2Icon,
  MessageCircleQuestionIcon,
} from "lucide-react";

import { useWorkspaces } from "@/presentation/hooks/use-workspaces";

// This is sample data.
const data = {
  teams: [
    {
      name: "Acme Inc",
      logo: <TerminalIcon />,
      plan: "Enterprise",
    },
    {
      name: "Acme Corp.",
      logo: <AudioLinesIcon />,
      plan: "Startup",
    },
    {
      name: "Evil Corp.",
      logo: <TerminalIcon />,
      plan: "Free",
    },
  ],
  navMain: [
    {
      title: "Search",
      url: "#",
      icon: <SearchIcon />,
    },
    {
      title: "Ask AI",
      url: "#",
      icon: <SparklesIcon />,
    },
    {
      title: "Home",
      url: "#",
      icon: <HomeIcon />,
      isActive: true,
    },
    {
      title: "Inbox",
      url: "#",
      icon: <InboxIcon />,
      badge: "10",
    },
  ],
  navSecondary: [
    {
      title: "Calendar",
      url: "#",
      icon: <CalendarIcon />,
    },
    {
      title: "Settings",
      url: "#",
      icon: <Settings2Icon />,
    },
    {
      title: "Templates",
      url: "#",
      icon: <BlocksIcon />,
    },
    {
      title: "Trash",
      url: "#",
      icon: <Trash2Icon />,
    },
    {
      title: "Help",
      url: "#",
      icon: <MessageCircleQuestionIcon />,
    },
  ],
};

export function AppSidebar({ ...props }: React.ComponentProps<typeof Sidebar>) {
  const { workspaces: apiWorkspaces, loading } = useWorkspaces();

  const workspaces = React.useMemo(() => {
    if (loading) return [];
    return apiWorkspaces.map((ws) => ({
      name: ws.name,

      pages: [], // Empty for now as API doesn't provide them
    }));
  }, [apiWorkspaces, loading]);

  return (
    <Sidebar className="border-r-0" {...props}>
      <SidebarHeader>
        <TeamSwitcher teams={data.teams} />
        <NavMain items={data.navMain} />
      </SidebarHeader>
      <SidebarContent>
        <NavWorkspaces workspaces={workspaces} />
        <NavSecondary items={data.navSecondary} className="mt-auto" />
      </SidebarContent>
      <SidebarRail />
    </Sidebar>
  );
}
