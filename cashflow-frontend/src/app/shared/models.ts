export interface TipoGasto {
  id: string;     // GUID como string
  nombre: string;
  codigo: string;
}

export interface FondoMonetario {
  id: number;
  nombre: string;
  saldo: number;
}
