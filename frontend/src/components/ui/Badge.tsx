
import type { ReactNode } from 'react';

type BadgeVariant = 'success' | 'danger' | 'info';

interface BadgeProps {
  children: ReactNode;
  variant?: BadgeVariant;
  className?: string;
}

const estilosPorVariante: Record<BadgeVariant, string> = {
  success: 'bg-success/15 text-success',
  danger: 'bg-danger/15 text-danger',
  info: 'bg-info/15 text-blue-400',
};

function Badge({
  children,
  variant = 'info',
  className = '',
}: BadgeProps) {
  return (
    <span
      className={`
        inline-flex items-center
        rounded-full px-3 py-1
        text-xs font-semibold
        ${estilosPorVariante[variant]}
        ${className}
      `}
    >
      {children}
    </span>
  );
}

export default Badge;
