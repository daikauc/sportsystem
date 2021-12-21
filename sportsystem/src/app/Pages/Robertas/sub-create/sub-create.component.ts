import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api-service';
import { ISub } from 'src/model/ISub';
import { DatePipe } from '@angular/common';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-sub-create',
  templateUrl: './sub-create.component.html',
  styleUrls: ['./sub-create.component.css']
})
export class SubCreateComponent implements OnInit {

  constructor(
    private service: ApiService
  ) { }

  date = new Date();

  ngOnInit(): void {
  }

  addSub() {
    let sub: ISub = {
      id: 0,
      userId: parseInt(localStorage.getItem('userId') || "0"),
      price: 50,
      type: "Paprastas",
      start: formatDate(new Date(), 'yyyy/MM/dd', 'en'),
      end: formatDate(this.date.setDate(this.date.getDate() + 30), 'yyyy/MM/dd', 'en'),
      stopped: false,
      discount: 0
    }

    this.service.addSub(sub).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }

}
