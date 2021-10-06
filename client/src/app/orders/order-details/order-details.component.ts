import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss'],
})
export class OrderDetailsComponent implements OnInit {
  order: IOrder;
  constructor(
    private route: ActivatedRoute,
    private orderService: OrdersService,
    private breadcrumbService: BreadcrumbService
  ) {
    this.breadcrumbService.set('@OrderDetailed', ' ');
  }

  ngOnInit(): void {
    var id = this.route.snapshot.params['id'];
    this.orderService.getOrderDetailed(+id).subscribe((O: IOrder) => {
      this.order = O;
      this.breadcrumbService.set(
        '@OrderDetailed',
        `Order# ${this.order.id} - ${this.order.status}`
      );
    });
  }
}
