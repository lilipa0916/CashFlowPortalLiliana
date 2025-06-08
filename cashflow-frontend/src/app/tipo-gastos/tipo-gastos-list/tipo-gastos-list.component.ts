import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TipoGasto } from '../../shared/models';
import { TipoGastosService } from '../../services/tipo-gastos.service';

@Component({
  selector: 'app-tipo-gastos-list',
  templateUrl: './tipo-gastos-list.component.html',
  styleUrls: ['./tipo-gastos-list.component.scss']
})
export class TipoGastosListComponent implements OnInit {
  tipoGastos: TipoGasto[] = [];
   displayedColumns: string[] = ['nombre', 'acciones'];

  constructor(
    private service: TipoGastosService,
    public router: Router
  ) {}                           

  ngOnInit(): void {
    this.service.getAll().subscribe(data => this.tipoGastos = data);
  }

  editar(id: string) {
    this.router.navigate(['tipo-gastos', id]);
  }

  borrar(id: string) {
    this.service.delete(id).subscribe(() => this.tipoGastos = this.tipoGastos.filter(t => t.id !== id));
  }
}
