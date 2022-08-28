import {Component, Input, OnInit} from '@angular/core';
import {Message} from "../../models/message";
import {RoomService} from "../../services/room.service";
import {RoomDetailed} from "../../models/room-detailed";
import {D} from "@angular/cdk/keycodes";
import {DataService} from "../../services/data.service";

@Component({
  selector: 'app-group-messages',
  templateUrl: './group-messages.component.html',
  styleUrls: ['./group-messages.component.css']
})
export class GroupMessagesComponent implements OnInit {

  roomDetails: RoomDetailed = {
    id: 2,
    name: "d",
    type: true,
    participantsNum: 1,
    messages: []
  };
  roomId: number;

  @Input()
  trigger: number;

  constructor(private roomService: RoomService,
              private dataService: DataService) { }

  ngOnInit(): void {
    this.subscribe();
    this.getMessages(this.roomId);
  }

  getMessages(roomId: number){
    this.roomService.getRoomMessages(roomId)
      .subscribe(response => {
          this.roomDetails = response;
        }
      );
  }

  subscribe(){
    this.dataService.roomId.subscribe(data =>{
      this.roomId = data;
    });

    console.log(this.roomId);
  }


}
