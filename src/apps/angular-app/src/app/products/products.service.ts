import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductCategory } from './models/ProductCategory';
import { AppConstants } from '../shared/app-constants';

@Injectable()
export class ProductsService {
    constructor(private httpClient: HttpClient) {
    }

    GetProductsCategories() : Observable<ProductCategory[]> {
        return this.httpClient.get<ProductCategory[]>(AppConstants.GET_PRODUCTS_CATEGORIES_URL());
    }
}