import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Distributions</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Create, approve, and track resource distributions.
      </Typography>
    </Box>
  );
}

export default { Component };
