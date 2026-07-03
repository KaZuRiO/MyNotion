"use client"

import { useState } from "react"
import { Command } from "lucide-react"
import Link from "next/link"
import { LoginForm } from "./login-form"
import { SignupForm } from "./signup-form"
import { AuthOverlay } from "./auth-overlay"
import { cn } from "@/shared/utils/utils"

interface AuthSliderProps {
  initialIsSignUp?: boolean
}

export function AuthSlider({ initialIsSignUp = false }: AuthSliderProps) {
  const [isSignUp, setIsSignUp] = useState(initialIsSignUp)

  const toggleMode = () => {
    setIsSignUp((prev) => !prev)
  }

  const mode = isSignUp ? "signup" : "login"

  return (
    <div className="relative w-full h-svh bg-white overflow-hidden">
      {/* Desktop Version */}
      <div className="hidden lg:flex h-full w-full">
        {/* Login Side (Left) */}
        <div className="w-1/2 h-full flex items-center justify-center p-6 md:p-10">
          <LoginForm onToggle={toggleMode} />
        </div>

        {/* Signup Side (Right) */}
        <div className="w-1/2 h-full flex items-center justify-center p-6 md:p-10">
          <SignupForm onToggle={toggleMode} />
        </div>

        {/* Sliding Overlay */}
        <div
          className={cn(
            "absolute top-0 w-1/2 h-full transition-all duration-700 ease-in-out z-20",
            !isSignUp ? "translate-x-full" : "translate-x-0"
          )}
        >
          <AuthOverlay mode={mode} onToggle={toggleMode} />
        </div>
      </div>

      {/* Mobile Version (Simplified Fade/Toggle) */}
      <div className="lg:hidden min-h-svh flex flex-col p-6 md:p-10">
        <div className="flex justify-center gap-2 md:justify-start mb-8">
          <Link href="/" className="flex items-center gap-2 font-medium">
            <div className="flex size-6 items-center justify-center rounded-md bg-primary text-primary-foreground">
              <Command className="size-4" />
            </div>
            MyNotion
          </Link>
        </div>
        <div className="flex flex-1 items-center justify-center transition-all duration-300">
          {isSignUp ? (
            <SignupForm onToggle={toggleMode} />
          ) : (
            <LoginForm onToggle={toggleMode} />
          )}
        </div>
      </div>
    </div>
  )
}
