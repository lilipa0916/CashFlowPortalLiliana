import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FondoMonetarioService } from '../../services/fondo-monetario.service';
import { FondoMonetario } from '../../shared/models';

@Component({
  selector: 'app-fondo-mon-form',
  templateUrl: './fondo-mon-form.component.html',
  styleUrls: ['./fondo-mon-form.component.scss']
})
export class FondoMonFormComponent implements OnInit {
  form!: FormGroup;
  id?: number;

  constructor(
    private fb: FormBuilder,
    private service: FondoMonetarioService,
    private route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      saldo: [0, [Validators.required, Validators.min(0)]]
    });

    const idParam = this.route.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : undefined;
    if (this.id != null) {
      this.service.getById(this.id).subscribe(dto => {
        this.form.patchValue(dto);
      });
    }
  }

  submit(): void {
    if (this.form.invalid) return;
    const dto: Omit<FondoMonetario, 'id'> = this.form.value;
    const obs = this.id != null
      ? this.service.update(this.id, dto)
      : this.service.create(dto);
    obs.subscribe(() => this.router.navigate(['fondo-monetario']));
  }
}
