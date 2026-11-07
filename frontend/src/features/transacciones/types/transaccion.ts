
export type TipoTransaccion = 1 | 2;

export interface Transaccion {
  id: number;
  nombre: string;
  descripcion: string | null;
  cantidad: number;
  tipo: TipoTransaccion;
  fecha: string;
}

export interface ResumenTransacciones {
  totalIngresos: number;
  totalGastos: number;
  saldo: number;
}

export interface CrearTransaccion {
  nombre: string;
  descripcion: string | null;
  cantidad: number;
  tipo: TipoTransaccion;
}
