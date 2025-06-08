import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FondoMonetario } from '../shared/models';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class FondoMonetarioService {
  private api = `${environment.apiUrl}/FondoMonetario`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<FondoMonetario[]> {
    return this.http.get<FondoMonetario[]>(this.api);
  }

  getById(id: number): Observable<FondoMonetario> {
    return this.http.get<FondoMonetario>(`${this.api}/${id}`);
  }

  create(dto: Omit<FondoMonetario, 'id'>): Observable<void> {
    return this.http.post<void>(this.api, dto);
  }

  update(id: number, dto: Omit<FondoMonetario, 'id'>): Observable<void> {
    return this.http.put<void>(`${this.api}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.api}/${id}`);
  }
}




// @Injectable({ providedIn: 'root' })
// export class FondoMonetarioService {
//   private api = `${environment.apiUrl}/FondoMonetario`;
//   constructor(private http: HttpClient) {}

//   getAll() { return this.http.get<FondoMonetario[]>(this.api); }
//   get(id: number) { return this.http.get<FondoMonetario>(`${this.api}/${id}`); }
//   create(dto: FondoMonetario) { return this.http.post<FondoMonetario>(this.api, dto); }
//   update(id: number, dto: FondoMonetario) { return this.http.put<void>(`${this.api}/${id}`, dto); }
//   delete(id: number) { return this.http.delete<void>(`${this.api}/${id}`); }
// }
