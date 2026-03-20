import { Box, Typography, type SxProps, type Theme } from '@mui/material';

interface AppPageHeaderProps {
  title: string;
  subtitle?: string;
  actions?: React.ReactNode;
  breadcrumbs?: React.ReactNode;
  sx?: SxProps<Theme>;
}

export function AppPageHeader({ title, subtitle, actions, breadcrumbs, sx }: AppPageHeaderProps) {
  return (
    <Box sx={{ mb: 3, ...sx as object }}>
      {breadcrumbs && <Box sx={{ mb: 1 }}>{breadcrumbs}</Box>}
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', flexWrap: 'wrap', gap: 2 }}>
        <Box>
          <Typography variant="h4">{title}</Typography>
          {subtitle && (
            <Typography variant="body1" color="text.secondary" sx={{ mt: 0.5 }}>
              {subtitle}
            </Typography>
          )}
        </Box>
        {actions && <Box sx={{ display: 'flex', gap: 1 }}>{actions}</Box>}
      </Box>
    </Box>
  );
}
