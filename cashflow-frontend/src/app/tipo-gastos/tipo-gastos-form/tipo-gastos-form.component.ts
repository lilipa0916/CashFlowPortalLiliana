import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoGasto } from '../../shared/models';
import { TipoGastosService } from '../../services/tipo-gastos.service';

@Component({
  selector: 'app-tipo-gastos-form',
  templateUrl: './tipo-gastos-form.component.html',
  styleUrls: ['./tipo-gastos-form.component.scss']
})
export class TipoGastosFormComponent implements OnInit {
  form!: FormGroup;
  id?: string;

  constructor(
    private fb: FormBuilder,
    private service: TipoGastosService,
    private route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      codigo: ['', Validators.required]
    });

    this.id = this.route.snapshot.paramMap.get('id') || undefined;
    if (this.id) {
      this.service.getById(this.id).subscribe(dto => {
        this.form.patchValue(dto);
      });
    }
  }

  submit(): void {
    if (this.form.invalid) return;
    const dto: TipoGasto = this.form.value;
    if (this.id) {
      this.service.update(this.id, dto).subscribe(() => this.router.navigate(['tipo-gastos']));
    } else {
      this.service.create(dto).subscribe(() => this.router.navigate(['tipo-gastos']));
    }
  }
}
