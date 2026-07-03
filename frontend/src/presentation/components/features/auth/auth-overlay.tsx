"use client"

import { Command } from "lucide-react"

interface AuthOverlayProps {
  mode: "login" | "signup"
  onToggle: () => void
}

export function AuthOverlay({ mode, onToggle }: AuthOverlayProps) {
  const isLogin = mode === "login"

  return (
    <div className="absolute inset-0 bg-zinc-900 text-white p-12 flex flex-col justify-center overflow-hidden">
      <div className="relative z-10 space-y-4 max-w-md mx-auto">
        <div className="flex items-center gap-2 text-2xl font-bold">
          <Command className="size-8" />
          MyNotion
        </div>
        
        {isLogin ? (
          <>
            <p className="text-lg text-zinc-400">
              The all-in-one workspace for your notes, tasks, wikis, and databases. 
              Organize your life and work in one place.
            </p>
            <blockquote className="space-y-2">
              <p className="text-zinc-300 italic">
                &ldquo;MyNotion has completely transformed how our team collaborates. 
                It&apos;s simple, powerful, and truly elegant.&rdquo;
              </p>
              <footer className="text-sm font-medium">Sofia Davis</footer>
            </blockquote>
          </>
        ) : (
          <>
            <p className="text-lg text-zinc-400">
              Join thousands of users who have streamlined their workflow with MyNotion. 
              Everything you need, exactly where you need it.
            </p>
            <blockquote className="space-y-2">
              <p className="text-zinc-300 italic">
                &ldquo;Join thousands of users who have streamlined their workflow with MyNotion. 
                Everything you need, exactly where you need it.&rdquo;
              </p>
              <footer className="text-sm font-medium">Michael Chen</footer>
            </blockquote>
          </>
        )}

        <div className="pt-8">
          <button
            onClick={onToggle}
            className="px-8 py-2 rounded-full border border-white/20 hover:bg-white/10 transition-colors"
          >
            {isLogin ? "Create an account" : "Sign in instead"}
          </button>
        </div>
      </div>
      
      <div className="absolute bottom-4 left-4 right-4 flex justify-center text-xs text-zinc-500">
        © 2026 MyNotion Inc. All rights reserved.
      </div>
    </div>
  )
}
