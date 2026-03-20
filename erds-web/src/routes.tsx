import { createBrowserRouter } from 'react-router-dom';
import { AppLayout } from '@/components/layout/AppLayout';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <AppLayout />,
    children: [
      {
        index: true,
        lazy: () => import('@/features/dashboard/DashboardPage'),
      },
      {
        path: 'inventory',
        lazy: () => import('@/features/inventory/InventoryPage'),
      },
      {
        path: 'distributions',
        lazy: () => import('@/features/distributions/DistributionsPage'),
      },
      {
        path: 'projects',
        lazy: () => import('@/features/projects/ProjectsPage'),
      },
      {
        path: 'reports',
        lazy: () => import('@/features/reports/ReportsPage'),
      },
      {
        path: 'admin',
        lazy: () => import('@/features/admin/AdminPage'),
      },
    ],
  },
]);
