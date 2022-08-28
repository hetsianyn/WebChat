import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Room} from "../../models/room";
import {RoomService} from "../../services/room.service";
import {DataService} from "../../services/data.service";

@Component({
  selector: 'app-room-list',
  templateUrl: 'room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  rooms: Room[] = [];


  constructor(private roomService: RoomService,
              private dataService: DataService) { }

  roomId: number = 1;

  ngOnInit(): void {
    // this.getAllRooms();
  }

  // getAllRooms(){
  //   this.roomService.getAllRooms()
  //     .subscribe(response => {
  //       this.rooms = response;
  //       }
  //     );
  // }
  //
  // roomSelectedEvent(room: Room){
  //
  //   console.log("Card SELECTED...");
  //
  //   console.log(room.id);
  //
  //   this.changeId(room.id);
  // }
  //
  // changeId(roomId: number){
  //   this.dataService.changeId(roomId);
  // }


}
