import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Inventory</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        Manage items, categories, stock balances, and transactions.
      </Typography>
    </Box>
  );
}

export default { Component };
