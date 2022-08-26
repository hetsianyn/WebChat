import { Component, OnInit } from '@angular/core';
import {Message} from "../../models/message";
import {RoomService} from "../../services/room.service";
import {RoomDetailed} from "../../models/room-detailed";

@Component({
  selector: 'app-group-messages',
  templateUrl: './group-messages.component.html',
  styleUrls: ['./group-messages.component.css']
})
export class GroupMessagesComponent implements OnInit {

  roomDetails: any;
  roomId: number = 1;

  constructor(private roomService: RoomService) { }

  ngOnInit(): void {
    this.getMessages(this.roomId);
  }

  getMessages(roomId: number){
    this.roomService.getRoomMessages(roomId)
      .subscribe(response => {
          this.roomDetails = response;
        }
      );
  }

}
