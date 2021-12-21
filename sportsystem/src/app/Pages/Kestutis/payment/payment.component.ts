import { Component, OnInit } from '@angular/core';
import { throwToolbarMixedModesError } from '@angular/material/toolbar';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api-service';
import { IItem } from 'src/model/IItem';
import { IUser } from 'src/model/IUser';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(
    private service: ApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  itemList: IItem[] = [];
  user: IUser = new IUser();
  error: string = "";

  changingItem: IItem = new IItem();

  ngOnInit(): void {
    this.service.getItemListByUserId(parseInt(localStorage.getItem('userId') || "0"))
      .subscribe(
        data => {
          this.itemList = data;
          console.log(this.itemList);
        },
        error => {
          console.log(error);
        }
      );

    this.service.getUserById(parseInt(localStorage.getItem('userId') || "0"))
      .subscribe(
        data => {
          this.user = data;
          console.log(this.user);
        },
        error => {
          console.log(error);
        }
      );

  }

  checkPayment() {
    let total: number = 6;
    this.itemList.forEach(item => {
      total += (item.price! - item.price! * item.discount! / 100) * item.quantity!;
    });

    if (total > this.user.balance) {
      this.error = "Nepakankamas balansas"
    }
    else {
      this.user.balance -= total;
      let route = this.activatedRoute.params.subscribe(params => {
        this.service.updateUser(this.user).subscribe()
      });

      this.clearCart();
    }
  }

  clearCart() {

    this.itemList.forEach(item => {
      let route = this.activatedRoute.params.subscribe(params => {
        this.service.getItemByName(item.name).subscribe(
          data => {
            this.changingItem = data;
            this.changingItem.quantity = this.changingItem.quantity! - item.quantity!;
            this.service.updateItem(this.changingItem).subscribe();
          },
          error => {
            console.log(error);
          }
        )

      });

      this.service.deleteItemFromCart(item.id).subscribe(() => this.route.navigate(["/home"]));
    });

  }
}
