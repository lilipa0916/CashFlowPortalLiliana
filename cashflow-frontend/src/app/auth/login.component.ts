import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form: FormGroup;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {
    this.form = this.fb.group({
      Usuario: ['', Validators.required],
      Clave: ['', Validators.required]
    });
  }

  submit() {
    if (this.form.invalid) {
      this.errorMessage = 'Por favor, completa todos los campos.';
      return;
    }
    const {  Usuario, Clave } = this.form.value;
    this.auth.login( Usuario, Clave).subscribe({
      next: () => this.router.navigate(['tipo-gastos']),
      error: () => {
        this.errorMessage = 'Credenciales inválidas.';
        this.form.reset();
      }
    });
  }
}