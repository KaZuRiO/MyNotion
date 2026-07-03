"use client"

import { AuthSlider } from "@/presentation/components/features/auth/auth-slider"
import { useSearchParams } from "next/navigation"
import { Suspense } from "react"

function AuthContent() {
  const searchParams = useSearchParams()
  const isSignUp = searchParams.get("mode") === "signup"

  return <AuthSlider initialIsSignUp={isSignUp} />
}

export default function AuthPage() {
  return (
    <Suspense fallback={<div className="min-h-svh flex items-center justify-center">Loading...</div>}>
      <AuthContent />
    </Suspense>
  )
}
