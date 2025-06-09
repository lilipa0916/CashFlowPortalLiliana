import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';

export interface LoginResponse {
  token: string;
  expires: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private api = `${environment.apiUrl}/Usuarios`;

  constructor(private http: HttpClient) {}

  login(Usuario: string, Clave: string): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(
        `${this.api}/login`,
        { Usuario, Clave },
        {
          // Descomenta si usas cookies/sesiones
          // withCredentials: true
        }
      )
      .pipe(
        tap(res => {
          if (res?.token) {
            localStorage.setItem('token', res.token);
          }
        }),
        catchError((error: HttpErrorResponse) => {
          console.error('Login failed:', error);
          return throwError(() => error);
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
