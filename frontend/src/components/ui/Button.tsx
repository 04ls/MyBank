
import type { ButtonHTMLAttributes } from 'react';

type ButtonVariant = 'primary' | 'secondary' | 'danger';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: ButtonVariant;
}

const estilosPorVariante: Record<ButtonVariant, string> = {
  primary:
    'bg-primary text-white hover:bg-primary-hover',
  secondary:
    'border border-border bg-surface-elevated text-text-primary hover:bg-border',
  danger:
    'bg-danger text-white hover:bg-danger/90',
};

function Button({
  children,
  variant = 'primary',
  type = 'button',
  className = '',
  disabled = false,
  ...props
}: ButtonProps) {
  return (
    <button
      type={type}
      disabled={disabled}
      className={`
        inline-flex items-center justify-center
        rounded-control px-4 py-2
        text-sm font-semibold
        transition-colors
        focus-visible:outline-2
        focus-visible:outline-offset-2
        focus-visible:outline-primary
        disabled:cursor-not-allowed
        disabled:opacity-50
        ${estilosPorVariante[variant]}
        ${className}
      `}
      {...props}
    >
      {children}
    </button>
  );
}

export default Button;
