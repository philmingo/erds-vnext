import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Reports</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Generate and view distribution and inventory reports.
      </Typography>
    </Box>
  );
}

export default { Component };
