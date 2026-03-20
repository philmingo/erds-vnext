// Shared utility functions
export function formatDate(date: Date | string): string {
  return new Date(date).toLocaleDateString('en-GY', {
    year: 'numeric',
    month: 'short',
    day: 'numeric',
  });
}
