import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IItem } from 'src/model/IItem';
import { ICart } from 'src/model/ICart';
import { IUser } from 'src/model/IUser';
import { IWorkout } from 'src/model/IWorkout';
import { IWorkoutRegistration } from 'src/model/IWorkoutRegistration';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly APIUrl = environment.APIUrl;

  constructor(private http: HttpClient) { }

  getItemList(): Observable<IItem[]> {
    return this.http.get<IItem[]>(this.APIUrl + 'Item');
  }

  getItemById(id: number): Observable<IItem> {
    return this.http.get<IItem>(this.APIUrl + 'Item/' + id);
  }

  getItemListByUserId(userId: number): Observable<IItem[]> {
    return this.http.get<IItem[]>(this.APIUrl + 'Item/list/' + userId);
  }

  getCartListById(id: number): Observable<ICart[]> {
    return this.http.get<ICart[]>(this.APIUrl + 'Cart/' + id);
  }

  addItemToCart(cartItem: ICart) {
    return this.http.post(this.APIUrl + 'Cart', cartItem);
  }

  addUser(user: IUser) {
    return this.http.post(this.APIUrl + 'User', user);
  }

  getUserLogin(login: string) {
    return this.http.get<IUser>(this.APIUrl + 'User/' + login);
  }

  deleteItemFromCart(id: number) {
    return this.http.delete(this.APIUrl + 'Cart/' + id);
  }

  addItem(item: IItem) {
    return this.http.post(this.APIUrl + 'Item', item);
  }

  updateItem(item: IItem) {
    return this.http.put(this.APIUrl + 'Item', item);
  }

  deleteItemFromList(id: number) {
    return this.http.delete(this.APIUrl + 'Item/' + id);
  }

  addWorkout(workout: IWorkout) {
    return this.http.post(this.APIUrl + 'Workout', workout);
  }

  updateWorkout(workout: IWorkout) {
    return this.http.put(this.APIUrl + 'Workout', workout);
  }

  deleteWorkoutFromList(id: number) {
    return this.http.delete(this.APIUrl + 'Workout/' + id);
  }

  getWorkoutList(): Observable<IWorkout[]> {
    return this.http.get<IWorkout[]>(this.APIUrl + 'Workout');
  }

  getMyWorkoutList(id: number): Observable<IWorkout[]> {
    return this.http.get<IWorkout[]>(this.APIUrl + 'WorkoutRegistration/' + id + '/0');
  }

  getWorkoutById(id: number): Observable<IWorkout> {
    return this.http.get<IWorkout>(this.APIUrl + 'Workout/' + id);
  }

  addWorkoutRegistration(userId: number, workoutId: number) {
    let params:IWorkoutRegistration = new IWorkoutRegistration()
    params.id = 0
    params.userId = userId
    params.workoutId = workoutId
    return this.http.post(this.APIUrl + 'WorkoutRegistration', params);
  }

  removeWorkoutRegistration(id: number) {
    return this.http.delete(this.APIUrl + 'WorkoutRegistration/' + id);
  }
}
