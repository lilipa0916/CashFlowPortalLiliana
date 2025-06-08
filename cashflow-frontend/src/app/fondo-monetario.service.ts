import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FondoMonetario } from '../shared/models';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class FondoMonetarioService {
  private api = `${environment.apiUrl}/FondoMonetario`;
  constructor(private http: HttpClient) {}

  getAll() { return this.http.get<FondoMonetario[]>(this.api); }
  get(id: number) { return this.http.get<FondoMonetario>(`${this.api}/${id}`); }
  create(dto: FondoMonetario) { return this.http.post<FondoMonetario>(this.api, dto); }
  update(id: number, dto: FondoMonetario) { return this.http.put<void>(`${this.api}/${id}`, dto); }
  delete(id: number) { return this.http.delete<void>(`${this.api}/${id}`); }
}
