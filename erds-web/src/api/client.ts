import { msalInstance } from '@/auth/AuthProvider';
import { apiScopes } from '@/auth/config';

const API_BASE_URL = '/api/v1';

async function getAuthHeaders(): Promise<HeadersInit> {
  const account = msalInstance.getActiveAccount();
  if (!account) return {};
  try {
    const result = await msalInstance.acquireTokenSilent({
      ...apiScopes,
      account,
    });
    return { Authorization: `Bearer ${result.accessToken}` };
  } catch {
    return {};
  }
}

export async function apiFetch<T>(path: string, init?: RequestInit): Promise<T> {
  const authHeaders = await getAuthHeaders();
  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...init,
    headers: {
      'Content-Type': 'application/json',
      ...authHeaders,
      ...init?.headers,
    },
  });

  if (!response.ok) {
    throw new Error(`API error: ${response.status} ${response.statusText}`);
  }

  return response.json() as Promise<T>;
}
