export interface TokenStorage {
  save(token: string): void;
  get(): string | null;
  clear(): void;
}
