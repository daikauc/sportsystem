import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api-service';
import { IWorkout } from 'src/model/IWorkout';
import { Router } from '@angular/router';

@Component({
  selector: 'app-workout-register',
  templateUrl: './workout-register.component.html',
  styleUrls: ['./workout-register.component.css']
})
export class WorkoutRegisterComponent implements OnInit {
  displayedColumns = ['name'];
  isLoadingResults = true;

  workoutList?: IWorkout[];

  constructor(private service: ApiService,
    private route: Router
  ) { }

  ngOnInit(): void {this.service.getWorkoutList()
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
  pushButton(id: number) {
    this.route.navigate(["workout-register-window/" + id]);
  }
}
