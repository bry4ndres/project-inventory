import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Transaction } from '../../../../core/models/transaction.model';
import { TransactionService } from '../../../../core/services/transaction.service';
import Swal from 'sweetalert2';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [CommonModule, RouterModule, NgxPaginationModule, FormsModule],
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.css',
})
export class TransactionListComponent {
  transactions: Transaction[] = [];

  searchText: string = '';
  filterType: string = '';
  currentPage = 1;

  constructor(private transactionService: TransactionService) {}

  ngOnInit(): void {
    this.loadTransactions();
  }

 loadTransactions() {
  this.transactionService.getAll().subscribe((data) => {
    this.transactions = data.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());
  });
}

  deleteTransaction(id: number) {
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
        this.transactionService.delete(id).subscribe(() => {
          this.transactions = this.transactions.filter((t) => t.id !== id);

          Swal.fire({
            icon: 'success',
            title: 'Eliminado!',
            text: 'La transación ha sido eliminada.',
            timer: 1500,
            showConfirmButton: false,
          });
        });
      }
    });
  }

  filteredTransactions(): Transaction[] {
    return this.transactions.filter(t => {
      const matchesType = this.filterType ? t.transactionType === this.filterType : true;
      const matchesSearch = !this.searchText ||
        t.detail?.toLowerCase().includes(this.searchText.toLowerCase()) ||
        t.transactionType?.toLowerCase().includes(this.searchText.toLowerCase());

      return matchesType && matchesSearch;
    });
  }
}

