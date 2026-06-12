"use client";

import { Button } from "@/presentation/components/ui/button";
import { Input } from "@/presentation/components/ui/input";
import { Separator } from "@/presentation/components/ui/separator";
import { User, Camera, ArrowDown, ShieldCheck } from "lucide-react";

export default function ProfilePage() {
  return (
    <div className="mx-auto w-full max-w-4xl space-y-8">
      {/* Header */}
      <div className="flex flex-col gap-1">
        <h1 className="text-3xl font-semibold tracking-tight">Your Profile</h1>
        <p className="text-muted-foreground">
          Manage your account settings and profile information.
        </p>
      </div>

      <Separator />

      <div className="grid gap-8 md:grid-cols-[240px,1px,1fr]">
        {/* Left Column: Avatar & Upload */}
        <div className="flex flex-col items-center space-y-4">
          <div className="group relative">
            <div className="flex h-48 w-48 items-center justify-center rounded-full bg-muted border-4 border-background shadow-sm overflow-hidden">
              <User className="h-24 w-24 text-muted-foreground/50" />
            </div>
            <button className="absolute inset-0 flex items-center justify-center rounded-full bg-black/40 opacity-0 transition-opacity group-hover:opacity-100">
              <Camera className="h-8 w-8 text-white" />
            </button>
          </div>
          <div className="text-center">
            <Button variant="outline" size="sm" className="font-medium">
              Change avatar
            </Button>
            <p className="mt-2 text-xs text-muted-foreground">
              JPG, GIF or PNG. Max size 2MB.
            </p>
          </div>
        </div>

        {/* Vertical Separator */}
        <Separator orientation="vertical" className="hidden md:block h-auto" />

        {/* Right Column: Form */}
        <div className="space-y-10">
          {/* Basic Info Section */}
          <section className="space-y-4">
            <h2 className="text-lg font-medium flex items-center gap-2">
              Personal Information
            </h2>
            <div className="grid gap-4 sm:grid-cols-2">
              <div className="space-y-2">
                <label className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70">
                  First Name
                </label>
                <Input placeholder="John" />
              </div>
              <div className="space-y-2">
                <label className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70">
                  Last Name
                </label>
                <Input placeholder="Doe" />
              </div>
            </div>
            <div className="space-y-2">
              <label className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70">
                Username
              </label>
              <Input placeholder="johndoe" />
            </div>
          </section>

          {/* Security Section */}
          <section className="space-y-6">
            <div className="flex items-center gap-2">
              <h2 className="text-lg font-medium">Security</h2>
              <Separator className="flex-1" />
            </div>
            
            <div className="rounded-xl border bg-card p-6 shadow-sm">
              <div className="flex flex-col items-center gap-6">
                <div className="flex flex-col items-center gap-2 text-center">
                  <div className="flex h-10 w-10 items-center justify-center rounded-full bg-primary/10 text-primary">
                    <ShieldCheck className="h-5 w-5" />
                  </div>
                  <h3 className="font-medium">Password Management</h3>
                  <p className="text-sm text-muted-foreground max-w-sm">
                    Keep your account secure by using a strong password.
                  </p>
                </div>

                <div className="w-full space-y-4 max-w-md">
                   <div className="flex flex-col items-center gap-2">
                     <Button variant="outline" className="w-full">
                       Request Password Reset
                     </Button>
                     <ArrowDown className="h-4 w-4 text-muted-foreground" />
                   </div>
                   
                   <div className="space-y-3 pt-2">
                     <div className="space-y-2">
                        <label className="text-sm font-medium">New Password</label>
                        <Input type="password" placeholder="••••••••" />
                     </div>
                     <div className="space-y-2">
                        <label className="text-sm font-medium">Confirm New Password</label>
                        <Input type="password" placeholder="••••••••" />
                     </div>
                   </div>
                </div>
              </div>
            </div>
          </section>

          {/* Footer Actions */}
          <div className="flex justify-end gap-3 pt-4">
            <Button variant="ghost">Cancel</Button>
            <Button>Save Changes</Button>
          </div>
        </div>
      </div>
    </div>
  );
}
