import { Component } from '@angular/core';
import { Product } from '../../../../core/models/product.model';
import { ProductService } from '../../../../core/services/product.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import Swal from 'sweetalert2';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, RouterModule,NgxPaginationModule,FormsModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent {
  products: Product[] = [];

  currentPage = 1;
  searchTerm = '';
  categoryFilter = '';
  categories: string[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getAll().subscribe((data) => {
       this.products = data;
       this.categories = Array.from(new Set(data.map((p) => p.category)));
    });
  }

  deleteProduct(id: number) {
    Swal.fire({
      title: 'Estas seguro?',
      text: 'Se eliminara permanentemente.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Eliminar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.productService.delete(id).subscribe(() => {
          this.products = this.products.filter((p) => p.id !== id);

          Swal.fire({
            icon: 'success',
            title: 'Eliminado!',
            text: 'El producto ha sido eliminado.',
            timer: 1500,
            showConfirmButton: false,
          });
        });
      }
    });
  }

  filteredProducts(): Product[] {
    return this.products.filter(product => {
      const matchesSearch =
        !this.searchTerm ||
        product.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        product.category.toLowerCase().includes(this.searchTerm.toLowerCase());

      const matchesCategory = !this.categoryFilter || product.category === this.categoryFilter;

      return matchesSearch && matchesCategory;
    });
  }
}
