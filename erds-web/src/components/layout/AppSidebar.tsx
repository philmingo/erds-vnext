import {
  Drawer,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Toolbar,
  Typography,
  Box,
} from '@mui/material';
import {
  Dashboard as DashboardIcon,
  Inventory2 as InventoryIcon,
  LocalShipping as DistributionsIcon,
  Assignment as ProjectsIcon,
  Assessment as ReportsIcon,
  Settings as AdminIcon,
} from '@mui/icons-material';
import { useNavigate, useLocation } from 'react-router-dom';

interface AppSidebarProps {
  width: number;
}

const navItems = [
  { label: 'Dashboard', path: '/', icon: <DashboardIcon /> },
  { label: 'Inventory', path: '/inventory', icon: <InventoryIcon /> },
  { label: 'Distributions', path: '/distributions', icon: <DistributionsIcon /> },
  { label: 'Projects', path: '/projects', icon: <ProjectsIcon /> },
  { label: 'Reports', path: '/reports', icon: <ReportsIcon /> },
  { label: 'Admin', path: '/admin', icon: <AdminIcon /> },
];

export function AppSidebar({ width }: AppSidebarProps) {
  const navigate = useNavigate();
  const location = useLocation();

  return (
    <Drawer
      variant="permanent"
      sx={{
        width,
        flexShrink: 0,
        '& .MuiDrawer-paper': { width, boxSizing: 'border-box' },
      }}
    >
      <Toolbar>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <Typography variant="h6" noWrap color="primary" fontWeight={700}>
            ERDS
          </Typography>
          <Typography variant="caption" color="text.secondary">
            vNext
          </Typography>
        </Box>
      </Toolbar>
      <List sx={{ px: 1 }}>
        {navItems.map((item) => {
          const isActive = item.path === '/'
            ? location.pathname === '/'
            : location.pathname.startsWith(item.path);
          return (
            <ListItemButton
              key={item.path}
              selected={isActive}
              onClick={() => navigate(item.path)}
              sx={{ borderRadius: 1, mb: 0.5 }}
            >
              <ListItemIcon sx={{ minWidth: 40 }}>{item.icon}</ListItemIcon>
              <ListItemText primary={item.label} />
            </ListItemButton>
          );
        })}
      </List>
    </Drawer>
  );
}
