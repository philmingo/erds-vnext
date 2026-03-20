import { Outlet } from 'react-router-dom';
import { Box } from '@mui/material';
import { AppSidebar } from './AppSidebar';
import { AppTopBar } from './AppTopBar';

const SIDEBAR_WIDTH = 260;

export function AppLayout() {
  return (
    <Box sx={{ display: 'flex', minHeight: '100vh' }}>
      <AppSidebar width={SIDEBAR_WIDTH} />
      <Box sx={{ flexGrow: 1, display: 'flex', flexDirection: 'column' }}>
        <AppTopBar />
        <Box component="main" sx={{ flexGrow: 1, p: 3, backgroundColor: 'background.default' }}>
          <Outlet />
        </Box>
      </Box>
    </Box>
  );
}
