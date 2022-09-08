import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
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

  dateNow: number = Date.now();

  messageTemplate: Message = {
    content: '',
    date: new Date(this.dateNow),
    userId: 1,
    roomId: this.subscribe()
  }

  selectedMessageId: number;
  deletedMessageId: number;
  display: boolean = false;


  @Input()
  trigger: number;

  @Output()
  newMessage = new EventEmitter<Message>();

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

    return this.roomId;
  }

  messageSelectedEvent(message: Message){

    console.log("Message selected");

    console.log(message.id);

    this.selectedMessageId = message.id;

    this.display = !this.display;
  }

  sendMessage(message: Message){
    this.roomService.createMessage(this.roomId, message)
      .subscribe((message: Message) => {
        this.newMessage.emit(message);
        this.ngOnInit()
      });

    this.messageTemplate.content = '';
  }

  deleteMessage(){
    this.roomService.deleteMessage(this.selectedMessageId)
      .subscribe(response => {
        this.deletedMessageId;
        this.ngOnInit();
      })

    this.display = !this.display;
  }

}
