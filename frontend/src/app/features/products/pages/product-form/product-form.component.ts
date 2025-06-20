import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../../core/services/product.service';
import { Product } from '../../../../core/models/product.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css',
})
export class ProductFormComponent {
  form!: FormGroup;
  isEditMode = false;
  productId?: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.buildForm();

    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.productId = +id;
        this.productService.getById(this.productId).subscribe(product => {
          this.form.patchValue(product);
        });
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      category: ['', Validators.required],
      image: [''],
      price: [0, [Validators.required, Validators.min(0.01)]],
      stock: [0, [Validators.required, Validators.min(0)]],
    });
  }

  onSubmit() {
    if (this.form.invalid)
      return;

    const product: Product = this.form.value;
    product.id = this.productId;

    if (this.isEditMode && this.productId) {
      this.productService.update(product).subscribe(() => {

        Swal.fire({
        icon: 'success',
        title: '¡Producto actualizado!',
        timer: 1500,
        showConfirmButton: false
      });

        setTimeout(() => {
        this.router.navigate(['/products']);
      }, 1500);
      });
    } else {
      this.productService.create(product).subscribe(() => {

        Swal.fire({
        icon: 'success',
        title: '¡Producto creado!',
        timer: 1500,
        showConfirmButton: false
      });

        setTimeout(() => {
        this.router.navigate(['/products']);
      }, 1500);
      });
    }
  }

}
