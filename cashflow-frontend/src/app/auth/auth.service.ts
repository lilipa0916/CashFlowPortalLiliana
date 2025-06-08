import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

export interface LoginResponse {
  token: string;
  expires: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private api = `${environment.apiUrl}/Usuarios`;
  constructor(private http: HttpClient) {}

login(Usuario: string, Clave: string) {
  return this.http
    .post<LoginResponse>(`${this.api}/login`, { Usuario, Clave })
    .pipe(tap(res => localStorage.setItem('token', res.token)));
}

  logout() {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
