import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Public Lookup</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Self-service resource receipt lookup for recipients.
      </Typography>
    </Box>
  );
}

export default { Component };
