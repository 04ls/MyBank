
import { useEffect, useState } from 'react';
import {
  obtenerResumen,
  obtenerTransacciones,
} from './features/transacciones/api/transaccionesApi';
import type {
  ResumenTransacciones,
  Transaccion,
} from './features/transacciones/types/transaccion';
import Card from './components/ui/Card';
import Badge from './components/ui/Badge';

const formatoMoneda = new Intl.NumberFormat('es-HN', {
  style: 'currency',
  currency: 'HNL',
});

const formatoFecha = new Intl.DateTimeFormat('es-HN', {
  day: '2-digit',
  month: 'short',
  year: 'numeric',
});

function App() {
  const [resumen, setResumen] = useState<ResumenTransacciones | null>(null);
  const [transacciones, setTransacciones] = useState<Transaccion[]>([]);
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function cargarDashboard() {
      try {
        setCargando(true);
        setError(null);

        const [datosResumen, datosTransacciones] = await Promise.all([
          obtenerResumen(),
          obtenerTransacciones(),
        ]);

        setResumen(datosResumen);
        setTransacciones(datosTransacciones);
      } catch (err) {
        setError(
          err instanceof Error
            ? err.message
            : 'No fue posible cargar la información.',
        );
      } finally {
        setCargando(false);
      }
    }

    cargarDashboard();
  }, []);

  return (
    <div className="min-h-screen bg-background text-text-primary">
      {/* Encabezado */}
      <header className="border-b border-border bg-surface">
        <div className="mx-auto flex max-w-7xl items-center justify-between px-6 py-5">
          <div>
            <h1 className="text-2xl font-bold tracking-tight text-text-primary">
              MyBank
            </h1>
            <p className="text-sm text-text-secondary">
              Control de ingresos y gastos
            </p>
          </div>

          <span className="rounded-full bg-primary/15 px-4 py-2 text-sm font-medium text-blue-400">
            Mi cuenta
          </span>
        </div>
      </header>

      <main className="mx-auto max-w-7xl px-6 py-8">
        {/* Resumen financiero */}
        <div className="mb-8">
          <h2 className="text-2xl font-bold text-text-primary">
            Resumen financiero
          </h2>
          <p className="mt-1 text-text-secondary">
            Consulta el estado actual de tus movimientos.
          </p>
        </div>

        {/* Cargando */}
        {cargando && (
          <p className="rounded-card border border-border bg-surface p-6 text-text-secondary">
            Cargando información...
          </p>
        )}

        {/* Error */}
        {error && (
          <div className="mb-6 rounded-card border border-danger/30 bg-danger/10 p-4 text-danger">
            <p className="font-semibold">
              No se pudo cargar el dashboard
            </p>
            <p className="mt-1 text-sm">{error}</p>
          </div>
        )}

        {!cargando && resumen && (
          <>
            {/* Tarjetas de resumen */}
            <section className="grid gap-5 md:grid-cols-3">
              <Card>
                <p className="text-sm font-medium text-text-secondary">
                  Total de ingresos
                </p>
                <p className="mt-3 text-2xl font-bold text-success">
                  {formatoMoneda.format(resumen.totalIngresos)}
                </p>
              </Card>

              <Card>
                <p className="text-sm font-medium text-text-secondary">
                  Total de gastos
                </p>
                <p className="mt-3 text-2xl font-bold text-danger">
                  {formatoMoneda.format(resumen.totalGastos)}
                </p>
              </Card>

              <article className="rounded-card bg-brand-dark p-6 shadow-sm">
                <p className="text-sm font-medium text-blue-200">
                  Saldo disponible
                </p>
                <p className="mt-3 text-2xl font-bold text-white">
                  {formatoMoneda.format(resumen.saldo)}
                </p>
              </article>
            </section>

            {/* Historial de movimientos */}
            <section className="mt-10">
              <div className="mb-5">
                <h2 className="text-xl font-bold text-text-primary">
                  Movimientos recientes
                </h2>
                <p className="mt-1 text-sm text-text-secondary">
                  Historial de ingresos y gastos registrados.
                </p>
              </div>

              <div className="overflow-hidden rounded-card border border-border bg-surface shadow-sm">
                {transacciones.length === 0 ? (
                  <p className="p-8 text-center text-text-secondary">
                    Todavía no hay movimientos registrados.
                  </p>
                ) : (
                  <div className="overflow-x-auto">
                    <table className="w-full text-left text-sm">
                      <thead className="bg-surface-elevated text-text-secondary">
                        <tr>
                          <th className="px-6 py-4 font-semibold">Nombre</th>
                          <th className="px-6 py-4 font-semibold">Fecha</th>
                          <th className="px-6 py-4 font-semibold">Tipo</th>
                          <th className="px-6 py-4 text-right font-semibold">
                            Cantidad
                          </th>
                        </tr>
                      </thead>

                      <tbody className="divide-y divide-border">
                        {transacciones.map((transaccion) => (
                          <tr
                            key={transaccion.id}
                            className="transition-colors hover:bg-surface-elevated"
                          >
                            <td className="px-6 py-4">
                              <p className="font-semibold text-text-primary">
                                {transaccion.nombre}
                              </p>
                              <p className="mt-1 text-xs text-text-secondary">
                                {transaccion.descripcion || 'Sin descripción'}
                              </p>
                            </td>

                            <td className="whitespace-nowrap px-6 py-4 text-text-secondary">
                              {formatoFecha.format(
                                new Date(transaccion.fecha),
                              )}
                            </td>

                            <td className="px-6 py-4">
                              <Badge
                                variant={transaccion.tipo === 1 ? 'success' : 'danger'}
                              >
                                {transaccion.tipo === 1 ? 'Ingreso' : 'Gasto'}
                              </Badge>
                            </td>

                            <td
                              className={`whitespace-nowrap px-6 py-4 text-right font-semibold ${
                                transaccion.tipo === 1
                                  ? 'text-success'
                                  : 'text-danger'
                              }`}
                            >
                              {transaccion.tipo === 1 ? '+' : '-'}
                              {formatoMoneda.format(transaccion.cantidad)}
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                )}
              </div>
            </section>
          </>
        )}
      </main>
    </div>
  );
}

export default App;
