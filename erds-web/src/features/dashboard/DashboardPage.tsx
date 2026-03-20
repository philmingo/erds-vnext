import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Dashboard</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Overview of resource distribution across the education system.
      </Typography>
    </Box>
  );
}

export default { Component };
