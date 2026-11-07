
import type { HTMLAttributes } from 'react';

interface CardProps extends HTMLAttributes<HTMLDivElement> {
  children: React.ReactNode;
}

function Card({
  children,
  className = '',
  ...props
}: CardProps) {
  return (
    <div
      className={`
        rounded-card
        border border-border
        bg-surface
        p-6
        shadow-sm
        ${className}
      `}
      {...props}
    >
      {children}
    </div>
  );
}

export default Card;
