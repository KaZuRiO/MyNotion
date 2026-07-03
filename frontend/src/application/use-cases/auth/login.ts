import { AuthRepository } from "@/application/ports/auth/auth-repository";
import { TokenStorage } from "@/application/ports/auth/token-storage";
import { LoginUserDto, LoginResponse } from "@/domain/entities/auth";

export class LoginUseCase {
  constructor(
    private authRepository: AuthRepository,
    private tokenStorage: TokenStorage,
  ) {}

  async execute(credentials: LoginUserDto): Promise<LoginResponse> {
    const response = await this.authRepository.login(credentials);
    if (response.flag && response.token) {
      this.tokenStorage.save(response.token);
    }
    return response;
  }
}
