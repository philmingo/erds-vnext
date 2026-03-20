import { LogLevel, type Configuration } from '@azure/msal-browser';

export const msalConfig: Configuration = {
  auth: {
    clientId: import.meta.env.VITE_AZURE_AD_CLIENT_ID ?? 'YOUR_CLIENT_ID',
    authority: `https://login.microsoftonline.com/${import.meta.env.VITE_AZURE_AD_TENANT_ID ?? 'YOUR_TENANT_ID'}`,
    redirectUri: window.location.origin,
    postLogoutRedirectUri: window.location.origin,
  },
  cache: {
    cacheLocation: 'localStorage',
    storeAuthStateInCookie: false,
  },
  system: {
    loggerOptions: {
      logLevel: LogLevel.Warning,
    },
  },
};

export const loginRequest = {
  scopes: [`api://${import.meta.env.VITE_AZURE_AD_CLIENT_ID ?? 'YOUR_CLIENT_ID'}/access_as_user`],
};

export const apiScopes = {
  scopes: [`api://${import.meta.env.VITE_AZURE_AD_CLIENT_ID ?? 'YOUR_CLIENT_ID'}/access_as_user`],
};
