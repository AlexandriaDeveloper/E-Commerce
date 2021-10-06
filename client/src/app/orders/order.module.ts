import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './orders-routing.module';
import { SharedModule } from '../shared/shared.module';
import { OrdersComponent } from './orders.component';
import { OrderDetailsComponent } from './order-details/order-details.component';

@NgModule({
  declarations: [OrdersComponent, OrderDetailsComponent],
  imports: [CommonModule, OrderRoutingModule, SharedModule],
})
export class OrderModule {}
