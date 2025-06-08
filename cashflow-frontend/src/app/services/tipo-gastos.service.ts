import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoGasto } from '../shared/models';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class TipoGastosService {
  private api = `${environment.apiUrl}/TipoGastos`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<TipoGasto[]> {
    return this.http.get<TipoGasto[]>(this.api);
  }

  getById(id: string): Observable<TipoGasto> {
    return this.http.get<TipoGasto>(`${this.api}/${id}`);
  }

  create(dto: Omit<TipoGasto, 'id'>): Observable<TipoGasto> {
    return this.http.post<TipoGasto>(this.api, dto);
  }

  update(id: string, dto: Omit<TipoGasto, 'id'>): Observable<void> {
    return this.http.put<void>(`${this.api}/${id}`, dto);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.api}/${id}`);
  }
}



// @Injectable({ providedIn: 'root' })
// export class TipoGastosService {
//   private api = `${environment.apiUrl}/TipoGastos`;
//   constructor(private http: HttpClient) {}

//   getAll() { return this.http.get<TipoGasto[]>(this.api); }
//   get(id: string) { return this.http.get<TipoGasto>(`${this.api}/${id}`); }
//   create(dto: TipoGasto) { return this.http.post<TipoGasto>(this.api, dto); }
//   update(id: string, dto: TipoGasto) { return this.http.put<void>(`${this.api}/${id}`, dto); }
//   delete(id: string) { return this.http.delete<void>(`${this.api}/${id}`); }
// }


