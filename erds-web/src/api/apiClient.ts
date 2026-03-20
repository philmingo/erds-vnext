import createClient from 'openapi-fetch';
import type { paths } from './schema';
import { msalInstance } from '@/auth/AuthProvider';
import { apiScopes } from '@/auth/config';

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

export const api = createClient<paths>({
  baseUrl: '/api/v1',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Attach auth token on every request
api.use({
  async onRequest({ request }) {
    const headers = await getAuthHeaders();
    for (const [key, value] of Object.entries(headers)) {
      request.headers.set(key, value);
    }
    return request;
  },
});
