import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';

import { Basket, IBasket, IBasketItem } from '../../models/basket';
import { IOrderItem } from '../../models/order';

@Component({
  selector: 'app-basket-summery',
  templateUrl: './basket-summery.component.html',
  styleUrls: ['./basket-summery.component.scss'],
})
export class BasketSummeryComponent implements OnInit {
  @Output() decrement: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();

  @Input() isBasket = true;
  @Input() isOrder = false;

  // @Input() items: IBasketItem[] | IOrderItem[] = [];
  @Input() items = [];
  constructor() {}

  ngOnInit(): void {}

  decrementItemQuantity(item: IBasketItem) {
    this.decrement.emit(item);
  }
  incrementItemQuantity(item: IBasketItem) {
    this.increment.emit(item);
  }
  removeBasketItem(item: IBasketItem) {
    this.remove.emit(item);
  }
}
