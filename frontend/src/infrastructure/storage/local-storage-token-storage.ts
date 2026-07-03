import { TokenStorage } from "@/application/ports/auth/token-storage";

const TOKEN_KEY = "token";

export class LocalStorageTokenStorage implements TokenStorage {
  save(token: string): void {
    if (typeof window !== "undefined") {
      localStorage.setItem(TOKEN_KEY, token);
    }
  }

  get(): string | null {
    return typeof window !== "undefined" ? localStorage.getItem(TOKEN_KEY) : null;
  }

  clear(): void {
    if (typeof window !== "undefined") {
      localStorage.removeItem(TOKEN_KEY);
    }
  }
}
