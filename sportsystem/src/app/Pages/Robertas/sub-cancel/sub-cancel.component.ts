import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api-service';

@Component({
  selector: 'app-sub-cancel',
  templateUrl: './sub-cancel.component.html',
  styleUrls: ['./sub-cancel.component.css']
})
export class SubCancelComponent implements OnInit {

  constructor(
    private service: ApiService
  ) { }

  ngOnInit(): void {
  }

  deleteSub() {
    this.service.deleteSub(parseInt(localStorage.getItem('userId') || "0")).subscribe(
      data => {

      },
      error => {
        console.log(error);
      }
    )

  }

}
