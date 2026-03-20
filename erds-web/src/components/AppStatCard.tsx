import { Card, CardContent, Typography, Box, type SxProps, type Theme } from '@mui/material';

interface AppStatCardProps {
  title: string;
  value: string | number;
  subtitle?: string;
  icon?: React.ReactNode;
  trend?: { value: string; positive?: boolean };
  sx?: SxProps<Theme>;
}

export function AppStatCard({ title, value, subtitle, icon, trend, sx }: AppStatCardProps) {
  return (
    <Card sx={{ height: '100%', ...sx as object }}>
      <CardContent sx={{ p: 2.5, '&:last-child': { pb: 2.5 } }}>
        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start' }}>
          <Typography variant="overline" color="text.secondary">
            {title}
          </Typography>
          {icon && <Box sx={{ color: 'text.secondary' }}>{icon}</Box>}
        </Box>
        <Box sx={{ display: 'flex', alignItems: 'baseline', gap: 1, mt: 1 }}>
          <Typography variant="h3" fontWeight={700}>
            {value}
          </Typography>
          {trend && (
            <Typography
              variant="body2"
              fontWeight={600}
              color={trend.positive ? 'success.main' : 'error.main'}
            >
              {trend.value}
            </Typography>
          )}
        </Box>
        {subtitle && (
          <Typography variant="caption" color="text.secondary" sx={{ mt: 0.5, display: 'block' }}>
            {subtitle}
          </Typography>
        )}
      </CardContent>
    </Card>
  );
}
