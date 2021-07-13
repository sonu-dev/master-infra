import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../shared/services/authentication.service';
import { first } from 'rxjs/operators';

@Component({
    selector: 'app-root',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    constructor(private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService) {
    }

    title = 'Login';
    user = {
        username: "",
        password: ""
    };
    returnUrl = "";
    error = "";


    ngOnInit() {
        // reset login status
        this.authenticationService.Logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    onLogin = () => {
        this.authenticationService.Login(this.user.username, this.user.password)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.error = error;
                });
    };
}