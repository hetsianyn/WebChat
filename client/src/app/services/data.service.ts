import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class DataService {

  private roomIdSource = new BehaviorSubject<number>(1);
  roomId = this.roomIdSource.asObservable()
  constructor() { }

  changeId(roomId: number){
    this.roomIdSource.next(roomId);
  }
}
