import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {Message} from "../../models/message";

@Component({
  selector: 'app-delete-message',
  templateUrl: './delete-message.component.html',
  styleUrls: ['./delete-message.component.css']
})
export class DeleteMessageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


}
