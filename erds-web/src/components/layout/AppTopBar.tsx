import { AppBar, Toolbar, Typography, Box, IconButton } from '@mui/material';
import { Notifications as NotificationsIcon } from '@mui/icons-material';

export function AppTopBar() {
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
          User
        </Typography>
      </Toolbar>
    </AppBar>
  );
}
