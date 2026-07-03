import { LoginResponse, LoginUserDto, RegisterUserDto, RegistrationResponse } from "@/domain/entities/auth";

export interface AuthRepository {
  login(credentials: LoginUserDto): Promise<LoginResponse>;
  register(userData: RegisterUserDto): Promise<RegistrationResponse>;
}
