import { TokenStorage } from "@/application/ports/auth/token-storage";

export class LogoutUseCase {
  constructor(private tokenStorage: TokenStorage) {}

  execute(): void {
    this.tokenStorage.clear();
  }
}
