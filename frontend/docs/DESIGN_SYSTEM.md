
# MyBank - Design System

**Versión:** 1.0  
**Estado:** Propuesta inicial  
**Proyecto:** MyBank

## 1. Introducción

El Design System de MyBank establece las reglas visuales y los componentes
reutilizables que se utilizarán en la interfaz de la aplicación.

Su propósito es mantener una experiencia visual consistente, moderna,
accesible y fácil de utilizar para la gestión de ingresos y gastos.

## 2. Principios de diseño

- **Simplicidad:** presentar la información financiera de forma clara.
- **Consistencia:** mantener los mismos estilos y comportamientos en toda
  la aplicación.
- **Jerarquía visual:** destacar los datos financieros más importantes.
- **Accesibilidad:** utilizar colores con suficiente contraste y textos
  legibles.
- **Adaptabilidad:** ofrecer una experiencia adecuada en computadoras,
  tablets y dispositivos móviles.

## 3. Identidad visual

MyBank utilizará una apariencia moderna y minimalista basada en un tema
oscuro.

El fondo oscuro permitirá destacar las tarjetas, los indicadores financieros
y las acciones principales de la aplicación.

## 4. Paleta de colores

### 4.1. Colores de fondo y superficies

| Nombre | Código | Uso |
|---|---|---|
| Background | #0F172A | Fondo principal |
| Surface | #1E293B | Tarjetas y paneles |
| Surface Elevated | #334155 | Elementos elevados |
| Border | #334155 | Bordes y divisores |

### 4.2. Colores de identidad y estados

| Nombre | Código | Uso |
|---|---|---|
| Primary | #2563EB | Acciones principales |
| Primary Dark | #172554 | Elementos destacados |
| Success | #10B981 | Ingresos y confirmaciones |
| Danger | #EF4444 | Gastos y acciones destructivas |
| Info | #3B82F6 | Información y notificaciones |

### 4.3. Colores de texto

| Nombre | Código | Uso |
|---|---|---|
| Text Primary | #F8FAFC | Títulos y contenido principal |
| Text Secondary | #94A3B8 | Descripciones y etiquetas |
| Text Muted | #64748B | Información complementaria |

## 5. Tipografía

La familia tipográfica principal será Inter.

| Elemento | Tamaño | Peso |
|---|---|---|
| Título principal | 30 px | Bold |
| Título de sección | 24 px | Semibold |
| Subtítulos | 18 px | Semibold |
| Texto normal | 16 px | Regular |
| Texto secundario | 14 px | Regular |
| Etiquetas | 12 px | Medium |

## 6. Espaciado

Se utilizará una escala basada en múltiplos de 4 px.

| Token | Tamaño |
|---|---|
| XS | 4 px |
| SM | 8 px |
| MD | 16 px |
| LG | 24 px |
| XL | 32 px |
| 2XL | 48 px |

## 7. Bordes y sombras

- Radio pequeño: 6 px.
- Radio mediano: 10 px.
- Radio grande: 16 px.
- Radio de elementos circulares: 9999 px.
- Los paneles utilizarán bordes sutiles y sombras discretas.

## 8. Componentes de interfaz

### Botones
- Primario: azul.
- Secundario: superficie oscura.
- Peligro: rojo.
- Deshabilitado: menor contraste y sin interacción.

### Tarjetas
- Fondo Surface.
- Bordes sutiles.
- Espaciado interno uniforme.
- Valores financieros destacados.

### Formularios
- Campos con fondo oscuro.
- Etiquetas visibles.
- Bordes diferenciados.
- Mensajes de validación claros.

### Etiquetas de estado
- Verde para ingresos.
- Rojo para gastos.
- Azul para información general.

### Tablas
- Encabezados diferenciados.
- Filas con separadores sutiles.
- Cantidades alineadas a la derecha.
- Colores semánticos para ingresos y gastos.

## 9. Diseño adaptable

La interfaz deberá adaptarse a:

- Escritorio: distribución amplia y tarjetas en varias columnas.
- Tablet: distribución flexible según el espacio disponible.
- Móvil: tarjetas apiladas y tablas con desplazamiento horizontal cuando
  sea necesario.

## 10. Accesibilidad

- Mantener contraste suficiente entre texto y fondo.
- No comunicar estados únicamente mediante colores.
- Utilizar etiquetas descriptivas en formularios.
- Mantener indicadores visibles de interacción y foco.
- Permitir navegación mediante teclado.

## 11. Tecnologías

La implementación del Design System utilizará:

- React.
- TypeScript.
- Tailwind CSS.
- CSS para variables y tokens de diseño.

## 12. Mantenimiento

Los colores, tipografías, espaciados y demás decisiones visuales deberán
centralizarse en los tokens de diseño.

Los componentes reutilizables deberán seguir estas reglas para mantener
la consistencia visual de MyBank.
