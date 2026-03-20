import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Notifications</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        System notifications and alerts.
      </Typography>
    </Box>
  );
}

export default { Component };
