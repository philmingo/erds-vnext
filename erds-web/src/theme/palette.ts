// ERDS Design System — Color Palette
// Based on guides/design.md

export const palette = {
  primary: {
    main: '#1B5E20',
    light: '#4C8C4A',
    dark: '#003300',
    contrastText: '#FFFFFF',
  },
  secondary: {
    main: '#FFC107',
    light: '#FFF350',
    dark: '#C79100',
    contrastText: '#1A1A1A',
  },
  error: {
    main: '#D32F2F',
    light: '#EF5350',
    dark: '#C62828',
  },
  warning: {
    main: '#ED6C02',
    light: '#FF9800',
    dark: '#E65100',
  },
  success: {
    main: '#2E7D32',
    light: '#4CAF50',
    dark: '#1B5E20',
  },
  info: {
    main: '#0288D1',
    light: '#03A9F4',
    dark: '#01579B',
  },
  background: {
    default: '#F5F5F5',
    paper: '#FFFFFF',
  },
  text: {
    primary: '#1A1A1A',
    secondary: '#616161',
  },
} as const;
