import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'skinet';

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}
  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(
        () => {
          console.log('initlized basket');
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }
  loadCurrentUser() {
    const token = localStorage.getItem('token');

      this.accountService.loadCurrentUser(token).subscribe(
        () => {
          console.log('loaded user ');
        },
        (err) => {
          console.log(err);
        }
      );
    
  }
}
