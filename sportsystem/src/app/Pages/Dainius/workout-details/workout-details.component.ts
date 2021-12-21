import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api-service';
import { IWorkout } from 'src/model/IWorkout';
import { Router } from '@angular/router';

@Component({
  selector: 'app-workout-details',
  templateUrl: './workout-details.component.html',
  styleUrls: ['./workout-details.component.css']
})
export class WorkoutDetailsComponent implements OnInit {

  workoutList?: IWorkout[];

  ngOnInit(): void {this.service.getMyWorkoutList(parseInt(localStorage.getItem('userId') || "0"))
    .subscribe(
      data => {
        this.workoutList = data;
        console.log(this.workoutList);
      },
      error => {
        console.log(error);
      }
    );
  }

  constructor(private service: ApiService,
    private route: Router
  ) { }

  pushButton(id: number) {
  }

  remove(id: number) {
    this.service.removeWorkoutRegistration(id).subscribe(
      data => {
        
      },
      error => {
        console.log(error);
      }
    );
    location.reload();
  }
}
