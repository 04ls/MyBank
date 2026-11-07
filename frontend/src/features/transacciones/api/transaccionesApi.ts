
import type {
  Transaccion,
  ResumenTransacciones,
  CrearTransaccion,
} from '../types/transaccion';

const API_URL = 'http://localhost:5116/api/transacciones';

// Función central para realizar solicitudes HTTP.
async function request<T>(
  url: string,
  options?: RequestInit,
): Promise<T> {
  const response = await fetch(url, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers,
    },
  });

  if (!response.ok) {
    const errorText = await response.text();

    let mensaje = 'Ocurrió un error al comunicarse con el servidor.';

    if (errorText) {
      try {
        const errorData = JSON.parse(errorText);

        if (errorData.errors) {
          mensaje = Object.values(errorData.errors)
            .flat()
            .join(' ');
        } else {
          mensaje = errorData.detail
            || errorData.title
            || mensaje;
        }
      } catch {
        mensaje = errorText;
      }
    }

    throw new Error(mensaje);
  }

  if (response.status === 204) {
    return undefined as T;
  }

  return response.json() as Promise<T>;
}

// Obtener todas las transacciones.
export function obtenerTransacciones(): Promise<Transaccion[]> {
  return request<Transaccion[]>(API_URL);
}

// Obtener el resumen financiero.
export function obtenerResumen(): Promise<ResumenTransacciones> {
  return request<ResumenTransacciones>(`${API_URL}/resumen`);
}

// Registrar una transacción.
export function crearTransaccion(
  datos: CrearTransaccion,
): Promise<Transaccion> {
  return request<Transaccion>(API_URL, {
    method: 'POST',
    body: JSON.stringify(datos),
  });
}

// Actualizar una transacción.
export function actualizarTransaccion(
  id: number,
  datos: CrearTransaccion,
): Promise<void> {
  return request<void>(`${API_URL}/${id}`, {
    method: 'PUT',
    body: JSON.stringify(datos),
  });
}

// Eliminar una transacción.
export function eliminarTransaccion(id: number): Promise<void> {
  return request<void>(`${API_URL}/${id}`, {
    method: 'DELETE',
  });
}
