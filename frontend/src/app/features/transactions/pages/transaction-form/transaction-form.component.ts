import { Component } from '@angular/core';
import { Product } from '../../../../core/models/product.model';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionService } from '../../../../core/services/transaction.service';
import { ProductService } from '../../../../core/services/product.service';
import { Transaction } from '../../../../core/models/transaction.model';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-transaction-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './transaction-form.component.html',
  styleUrl: './transaction-form.component.css',
})
export class TransactionFormComponent {
  form!: FormGroup;
  isEditMode = false;
  transactionId?: number;
  products: Product[] = [];
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private transactionService: TransactionService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.buildForm();

    this.productService.getAll().subscribe((data) => {
      this.products = data;

      this.form.get('productId')?.valueChanges.subscribe((productId) => {
        const selectedProduct = this.products.find((p) => p.id === +productId);
        if (selectedProduct) {
          this.form.get('unitPrice')?.setValue(selectedProduct.price);
        } else {
          this.form.get('unitPrice')?.reset();
        }
      });
    });

    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.transactionId = +id;
        this.transactionService
          .getById(this.transactionId)
          .subscribe((transaction) => {
            this.form.patchValue(transaction);
          });
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      date: ['', Validators.required],
      transactionType: ['', Validators.required],
      productId: [null, Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      unitPrice: [
        { value: '', disabled: true },
        [Validators.required, Validators.min(0.01)],
      ],
      detail: [''],
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    this.isLoading = true;

    const formData = this.form.getRawValue();

    const transaction: Transaction = {
    ...formData,
    totalPrice: formData.quantity * formData.unitPrice,
  };

    const selectedProduct = this.products.find(
      (p) => p.id === +transaction.productId
    );

    if (
      transaction.transactionType === 'Venta' &&
      transaction.productId &&
      transaction.quantity > selectedProduct!.stock
    ) {
      this.isLoading = false;
      Swal.fire({
        icon: 'warning',
        title: 'Stock insuficiente',
        text: `El producto "${selectedProduct!.name}" tiene solo ${
          selectedProduct!.stock
        } unidades en stock.`,
      });
      return;
    }

    if (this.isEditMode && this.transactionId) {
      transaction.id = this.transactionId;
      this.transactionService.update(transaction).subscribe({
        next: () => {
          this.isLoading = false;
          Swal.fire({
            icon: 'success',
            title: 'Transacción actualizada!',
            timer: 1500,
            showConfirmButton: false,
          });
          this.router.navigate(['/transactions']);
        },
        error: () => {
          this.isLoading = false;
          Swal.fire({
            icon: 'error',
            title: 'Error al actualizar la transacción',
          });
        },
      });
    } else {
      this.transactionService.create(transaction).subscribe({
        next: () => {
          this.isLoading = false;
          Swal.fire({
            icon: 'success',
            title: 'Transacción creada!',
            timer: 1500,
            showConfirmButton: false,
          });
          this.router.navigate(['/transactions']);
        },
        error: () => {
          this.isLoading = false;
          Swal.fire({ icon: 'error', title: 'Error al crear la transacción' });
        },
      });
    }
  }
}
