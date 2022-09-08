import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Room} from "./models/room";
import {RoomService} from "./services/room.service";
import {DataService} from "./services/data.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = "Web Chat";
  display = false;


  constructor(private http:HttpClient,
              private roomService: RoomService,
              private dataService: DataService) {}

  ngOnInit(): void {
    this.getAllRooms();
  }

  onPress() {
    //To toggle the component
    this.display = !this.display;
  }

  rooms: Room[] = [];

  roomId: number = 1;



  getAllRooms(){
    this.roomService.getAllRooms()
      .subscribe(response => {
          this.rooms = response;
        }
      );
  }

  roomSelectedEvent(room: Room){

    console.log("Card SELECTED...");

    console.log(room.id);

    this.changeId(room.id);

    this.roomId++;
  }

  changeId(roomId: number){
    this.dataService.changeId(roomId);
  }


}
