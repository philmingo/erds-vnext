import { useMsal } from '@azure/msal-react';
import { loginRequest } from './config';

export function useAuth() {
  const { instance, accounts } = useMsal();
  const account = accounts[0] ?? null;

  const logout = () => instance.logoutRedirect();

  const getAccessToken = async (): Promise<string> => {
    if (!account) throw new Error('No active account');
    const result = await instance.acquireTokenSilent({
      ...loginRequest,
      account,
    });
    return result.accessToken;
  };

  return {
    isAuthenticated: !!account,
    user: account
      ? { name: account.name ?? '', email: account.username ?? '' }
      : null,
    getAccessToken,
    logout,
  };
}
