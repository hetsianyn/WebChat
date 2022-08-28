import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Room} from "../models/room";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {RoomDetailed} from "../models/room-detailed";

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private url = "rooms";

  constructor(private http: HttpClient) { }

  //Get Rooms from api
  getAllRooms(): Observable<Room[]>{
    return this.http.get<Room[]>(`${environment.apiUrl}/${this.url}`);
  }

  getRoomMessages(roomId: number): Observable<RoomDetailed>{
    return this.http.get<RoomDetailed>(`${environment.apiUrl}/${this.url}/${roomId}`)
  }
}
