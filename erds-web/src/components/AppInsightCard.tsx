import { Card, CardContent, Typography, Box, type SxProps, type Theme } from '@mui/material';
import { AutoAwesome as AiIcon } from '@mui/icons-material';

interface AppInsightCardProps {
  title: string;
  content: string;
  label?: string;
  action?: React.ReactNode;
  sx?: SxProps<Theme>;
}

export function AppInsightCard({ title, content, label = 'AI Insight', action, sx }: AppInsightCardProps) {
  return (
    <Card
      sx={{
        borderLeft: 4,
        borderColor: 'secondary.main',
        background: 'linear-gradient(135deg, #FFFDE7 0%, #FFFFFF 100%)',
        ...sx as object,
      }}
    >
      <CardContent sx={{ p: 2.5, '&:last-child': { pb: 2.5 } }}>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1, mb: 1 }}>
          <AiIcon sx={{ fontSize: 18, color: 'secondary.dark' }} />
          <Typography variant="overline" color="secondary.dark" fontWeight={700}>
            {label}
          </Typography>
        </Box>
        <Typography variant="subtitle2" fontWeight={600} gutterBottom>
          {title}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {content}
        </Typography>
        {action && <Box sx={{ mt: 1.5 }}>{action}</Box>}
      </CardContent>
    </Card>
  );
}
