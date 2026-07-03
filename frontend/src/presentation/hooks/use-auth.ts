import { useMemo } from "react";
import { LoginUserDto, RegisterUserDto } from "@/domain/entities/auth";
import { AuthRepositoryImpl } from "@/infrastructure/repositories/auth-repository.impl";
import { LocalStorageTokenStorage } from "@/infrastructure/storage/local-storage-token-storage";
import { LoginUseCase } from "@/application/use-cases/auth/login";
import { RegisterUseCase } from "@/application/use-cases/auth/register";
import { LogoutUseCase } from "@/application/use-cases/auth/logout";

export function useAuth() {
  const authRepository = useMemo(() => new AuthRepositoryImpl(), []);
  const tokenStorage = useMemo(() => new LocalStorageTokenStorage(), []);

  const login = (credentials: LoginUserDto) =>
    new LoginUseCase(authRepository, tokenStorage).execute(credentials);

  const register = (userData: RegisterUserDto) =>
    new RegisterUseCase(authRepository).execute(userData);

  const logout = () => new LogoutUseCase(tokenStorage).execute();

  return { login, register, logout };
}
