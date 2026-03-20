import { useEffect, useState, type ReactNode } from 'react';
import {
  MsalProvider,
  AuthenticatedTemplate,
  UnauthenticatedTemplate,
  useMsal,
} from '@azure/msal-react';
import {
  PublicClientApplication,
  EventType,
  type AuthenticationResult,
} from '@azure/msal-browser';
import { Box, Button, Typography, Stack } from '@mui/material';
import { msalConfig, loginRequest } from './config';

export const msalInstance = new PublicClientApplication(msalConfig);

function AuthGuard({ children }: { children: ReactNode }) {
  const { instance } = useMsal();

  const handleLogin = () => {
    instance.loginRedirect(loginRequest);
  };

  return (
    <>
      <AuthenticatedTemplate>{children}</AuthenticatedTemplate>
      <UnauthenticatedTemplate>
        <Box
          sx={{
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            minHeight: '100vh',
            backgroundColor: 'background.default',
          }}
        >
          <Stack spacing={3} alignItems="center">
            <Typography variant="h4" fontWeight={700}>
              ERDS vNext
            </Typography>
            <Typography variant="body1" color="text.secondary">
              Educational Resource Distribution System
            </Typography>
            <Button variant="contained" size="large" onClick={handleLogin}>
              Sign in with Microsoft
            </Button>
          </Stack>
        </Box>
      </UnauthenticatedTemplate>
    </>
  );
}

export function AuthProvider({ children }: { children: ReactNode }) {
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    msalInstance.initialize().then(() => {
      const accounts = msalInstance.getAllAccounts();
      if (accounts.length > 0) {
        msalInstance.setActiveAccount(accounts[0]);
      }

      msalInstance.addEventCallback((event) => {
        if (event.eventType === EventType.LOGIN_SUCCESS && event.payload) {
          const result = event.payload as AuthenticationResult;
          msalInstance.setActiveAccount(result.account);
        }
      });

      setIsReady(true);
    });
  }, []);

  if (!isReady) return null;

  return (
    <MsalProvider instance={msalInstance}>
      <AuthGuard>{children}</AuthGuard>
    </MsalProvider>
  );
}
