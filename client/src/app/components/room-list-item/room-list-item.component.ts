import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Room} from "../../models/room";

@Component({
  selector: 'app-room-list-item',
  templateUrl: './room-list-item.component.html',
  styleUrls: ['./room-list-item.component.css']
})
export class RoomListItemComponent implements OnInit {

  @Input()
  room: Room;

  @Output()
  roomSelected = new EventEmitter<Room>();



  constructor() { }

  ngOnInit(): void {
  }

  onRoomClicked(){
    this.roomSelected.emit(this.room);
  }

}
