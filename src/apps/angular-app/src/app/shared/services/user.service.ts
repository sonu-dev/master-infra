import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { AppConstants } from '../app-constants';

@Injectable()
export class UserService {
    constructor(private httpClient: HttpClient) {
    }

    GetUsers(userId: number[]): Observable<User> {
        return this.httpClient.get<User>(AppConstants.GET_USER_API);
    }
}