// ERDS Design System — Typography
// Font: Inter (Google Fonts)

import type { ThemeOptions } from '@mui/material/styles';

export const typography: ThemeOptions['typography'] = {
  fontFamily: '"Inter", "Roboto", "Helvetica", "Arial", sans-serif',
  h1: { fontSize: '2rem', fontWeight: 700, lineHeight: 1.2 },
  h2: { fontSize: '1.5rem', fontWeight: 700, lineHeight: 1.3 },
  h3: { fontSize: '1.25rem', fontWeight: 600, lineHeight: 1.4 },
  h4: { fontSize: '1.125rem', fontWeight: 600, lineHeight: 1.4 },
  h5: { fontSize: '1rem', fontWeight: 600, lineHeight: 1.5 },
  h6: { fontSize: '0.875rem', fontWeight: 600, lineHeight: 1.5 },
  subtitle1: { fontSize: '1rem', fontWeight: 500, lineHeight: 1.5 },
  subtitle2: { fontSize: '0.875rem', fontWeight: 500, lineHeight: 1.5 },
  body1: { fontSize: '0.875rem', fontWeight: 400, lineHeight: 1.6 },
  body2: { fontSize: '0.8125rem', fontWeight: 400, lineHeight: 1.6 },
  button: { fontSize: '0.875rem', fontWeight: 600, textTransform: 'none' },
  caption: { fontSize: '0.75rem', fontWeight: 400, lineHeight: 1.4 },
  overline: { fontSize: '0.75rem', fontWeight: 600, letterSpacing: '0.08em', textTransform: 'uppercase' },
};
