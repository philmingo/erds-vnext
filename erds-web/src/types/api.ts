// Shared API response type — mirrors backend ApiResponse<T>
export interface ApiResponse<T> {
  success: boolean;
  data: T | null;
  message: string | null;
  errors: string[];
}
