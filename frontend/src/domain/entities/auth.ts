export interface LoginUserDto {
  email: string;
  password?: string;
}

export interface RegisterUserDto {
  username: string;
  email: string;
  password?: string;
  confirmPassword?: string;
}

export interface LoginResponse {
  flag: boolean;
  message: string;
  token?: string;
}

export interface RegistrationResponse {
  flag: boolean;
  message: string;
}
