import { AuthRepository } from "@/application/ports/auth/auth-repository";
import { LoginResponse, LoginUserDto, RegisterUserDto, RegistrationResponse } from "@/domain/entities/auth";
import { apiFetch } from "@/infrastructure/api/http-client";

export class AuthRepositoryImpl implements AuthRepository {
  async login(credentials: LoginUserDto): Promise<LoginResponse> {
    return apiFetch<LoginResponse>("/Auth/Login", {
      method: "POST",
      body: JSON.stringify(credentials),
    });
  }

  async register(userData: RegisterUserDto): Promise<RegistrationResponse> {
    return apiFetch<RegistrationResponse>("/Auth/Register", {
      method: "POST",
      body: JSON.stringify(userData),
    });
  }
}
