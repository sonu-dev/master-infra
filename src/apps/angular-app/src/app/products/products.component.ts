import { Component } from '@angular/core';
import { ProductCategory } from './models/ProductCategory';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-root',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {
 public title = 'Products Categories';

  public productsCategories: ProductCategory[];

  constructor(private productsService: ProductsService) {
  }

  loadProducts() {
   this.productsService.GetProductsCategories().subscribe(products => {    
     this.productsCategories = [];
     this.productsCategories = products;
   }, (error) => console.log(error)
   );
  }
}