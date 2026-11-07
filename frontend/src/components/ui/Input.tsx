
import type { InputHTMLAttributes } from 'react';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  label: string;
  error?: string;
}

function Input({
  label,
  error,
  id,
  className = '',
  ...props
}: InputProps) {
  const inputId = id ?? props.name ?? label
    .toLowerCase()
    .replace(/\s+/g, '-');

  return (
    <div className="flex flex-col gap-2">
      <label
        htmlFor={inputId}
        className="text-sm font-medium text-text-primary"
      >
        {label}
      </label>

      <input
        id={inputId}
        className={`
          w-full rounded-control
          border bg-surface-elevated
          px-4 py-3
          text-text-primary
          placeholder:text-text-muted
          outline-none transition-colors
          focus:border-primary focus:ring-2 focus:ring-primary/20
          disabled:cursor-not-allowed disabled:opacity-50
          ${error ? 'border-danger' : 'border-border'}
          ${className}
        `}
        aria-invalid={Boolean(error)}
        aria-describedby={error ? `${inputId}-error` : undefined}
        {...props}
      />

      {error && (
        <p
          id={`${inputId}-error`}
          className="text-sm text-danger"
        >
          {error}
        </p>
      )}
    </div>
  );
}

export default Input;
