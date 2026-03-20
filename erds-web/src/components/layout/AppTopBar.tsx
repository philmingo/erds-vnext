import { AppBar, Toolbar, Typography, Box, IconButton } from '@mui/material';
import {
  Notifications as NotificationsIcon,
  Logout as LogoutIcon,
} from '@mui/icons-material';
import { useAuth } from '@/auth/useAuth';

export function AppTopBar() {
  const { user, logout } = useAuth();

  return (
    <AppBar
      position="sticky"
      color="inherit"
      elevation={0}
      sx={{ borderBottom: '1px solid', borderColor: 'divider' }}
    >
      <Toolbar>
        <Box sx={{ flexGrow: 1 }} />
        <IconButton size="small">
          <NotificationsIcon />
        </IconButton>
        <Typography variant="body2" sx={{ ml: 2 }}>
          {user?.name ?? 'User'}
        </Typography>
        <IconButton size="small" sx={{ ml: 1 }} onClick={logout} title="Sign out">
          <LogoutIcon fontSize="small" />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
}
