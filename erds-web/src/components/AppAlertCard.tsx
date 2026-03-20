import { Card, CardContent, Typography, Box, Chip, type SxProps, type Theme } from '@mui/material';

type AlertSeverity = 'info' | 'warning' | 'urgent';

const severityColors: Record<AlertSeverity, string> = {
  info: '#0288D1',
  warning: '#ED6C02',
  urgent: '#D32F2F',
};

interface AppAlertCardProps {
  severity: AlertSeverity;
  title: string;
  message: string;
  action?: React.ReactNode;
  sx?: SxProps<Theme>;
}

export function AppAlertCard({ severity, title, message, action, sx }: AppAlertCardProps) {
  return (
    <Card
      sx={{
        borderLeft: 4,
        borderColor: severityColors[severity],
        ...sx as object,
      }}
    >
      <CardContent sx={{ p: 2, '&:last-child': { pb: 2 } }}>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 0.5 }}>
          <Chip
            label={severity.toUpperCase()}
            size="small"
            sx={{
              bgcolor: severityColors[severity],
              color: '#fff',
              fontWeight: 600,
              fontSize: '0.7rem',
              height: 20,
            }}
          />
          <Typography variant="subtitle2" fontWeight={600}>
            {title}
          </Typography>
        </Box>
        <Typography variant="body2" color="text.secondary">
          {message}
        </Typography>
        {action && <Box sx={{ mt: 1 }}>{action}</Box>}
      </CardContent>
    </Card>
  );
}
