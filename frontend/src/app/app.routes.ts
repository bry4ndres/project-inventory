import { Routes } from '@angular/router';
import { ProductListComponent } from './features/products/pages/product-list/product-list.component';
import { TransactionListComponent } from './features/transactions/pages/transaction-list/transaction-list.component';
import { ProductFormComponent } from './features/products/pages/product-form/product-form.component';
import { TransactionFormComponent } from './features/transactions/pages/transaction-form/transaction-form.component';

export const routes: Routes = [
   { path: '', redirectTo: 'transactions', pathMatch: 'full' },

   { path: 'products', component: ProductListComponent },
   { path: 'products/create', component: ProductFormComponent },
   { path: 'products/edit/:id', component: ProductFormComponent },

   { path: 'transactions', component: TransactionListComponent },
   { path: 'transactions/create', component: TransactionFormComponent },
   { path: 'transactions/edit/:id', component: TransactionFormComponent },
];
