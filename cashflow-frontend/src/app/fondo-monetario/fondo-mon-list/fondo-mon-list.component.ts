import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FondoMonetario } from '../../shared/models';
import { FondoMonetarioService } from '../../services/fondo-monetario.service';

@Component({
  selector: 'app-fondo-mon-list',
  templateUrl: './fondo-mon-list.component.html',
  styleUrls: ['./fondo-mon-list.component.scss']
})
export class FondoMonListComponent implements OnInit {
  fondos: FondoMonetario[] = [];

  constructor(
    private service: FondoMonetarioService,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.service.getAll().subscribe(data => this.fondos = data);
  }

  editar(f: FondoMonetario) {
    this.router.navigate(['fondo-monetario', f.id]);
  }

  borrar(id: number) {
    this.service.delete(id).subscribe(() =>
      this.fondos = this.fondos.filter(x => x.id !== id)
    );
  }
}