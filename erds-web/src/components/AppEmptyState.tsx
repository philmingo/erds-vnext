import { Box, Typography, Button, type SxProps, type Theme } from '@mui/material';

interface AppEmptyStateProps {
  title: string;
  message: string;
  actionLabel?: string;
  onAction?: () => void;
  icon?: React.ReactNode;
  sx?: SxProps<Theme>;
}

export function AppEmptyState({ title, message, actionLabel, onAction, icon, sx }: AppEmptyStateProps) {
  return (
    <Box
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        py: 8,
        px: 3,
        textAlign: 'center',
        ...sx as object,
      }}
    >
      {icon && (
        <Box sx={{ mb: 2, color: 'text.secondary', '& svg': { fontSize: 48 } }}>
          {icon}
        </Box>
      )}
      <Typography variant="h5" gutterBottom>
        {title}
      </Typography>
      <Typography variant="body1" color="text.secondary" sx={{ maxWidth: 400, mb: actionLabel ? 3 : 0 }}>
        {message}
      </Typography>
      {actionLabel && onAction && (
        <Button variant="contained" onClick={onAction}>
          {actionLabel}
        </Button>
      )}
    </Box>
  );
}
