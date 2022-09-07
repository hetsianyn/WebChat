import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Room} from "../models/room";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {RoomDetailed} from "../models/room-detailed";
import {Message} from "../models/message";

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

  createMessage(roomId: number, message: Message): Observable<Message>{
    return this.http.post<Message>(`${environment.apiUrl}/message`, message);
  }

  deleteMessage(messageId: number){
    return this.http.delete(`${environment.apiUrl}/message/${messageId}`);
  }

}
