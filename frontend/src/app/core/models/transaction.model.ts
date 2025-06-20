export interface Transaction {
  id?: number;
  date: string;
  transactionType: 'Venta' | 'Compra';
  productId: number;
  quantity: number;
  unitPrice: number;
  totalPrice?: number;
  detail?: string;
}
