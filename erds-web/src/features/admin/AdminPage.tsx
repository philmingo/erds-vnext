import { Typography, Box } from '@mui/material';

export function Component() {
  return (
    <Box>
      <Typography variant="h4">Administration</Typography>
      <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
        System configuration, users, roles, and permissions.
      </Typography>
    </Box>
  );
}

export default { Component };
