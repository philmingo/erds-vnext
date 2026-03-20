import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Projects</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Plan and manage distribution projects and campaigns.
      </Typography>
    </Box>
  );
}

export default { Component };
