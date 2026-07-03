import { AuthRepository } from "@/application/ports/auth/auth-repository";
import { RegisterUserDto, RegistrationResponse } from "@/domain/entities/auth";

export class RegisterUseCase {
  constructor(private authRepository: AuthRepository) {}

  async execute(userData: RegisterUserDto): Promise<RegistrationResponse> {
    return this.authRepository.register(userData);
  }
}
