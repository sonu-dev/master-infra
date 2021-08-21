import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDeatilsComponent implements OnInit {
  title = 'Product Details';

  constructor(private route: ActivatedRoute) {
    this.productCategoryId = Number(this.route.snapshot.paramMap.get('catId'));
  }

  productCategoryId: number;

  ngOnInit(): void {    
  }
}