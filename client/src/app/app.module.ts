import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from "@angular/material/button";
import { GroupMessagesComponent } from './components/group-messages/group-messages.component';
import { RoomListItemComponent } from './components/room-list-item/room-list-item.component';
import {NgxRerenderModule} from "ngx-rerender";
import {FormsModule} from "@angular/forms";
import { DeleteMessageComponent } from './components/delete-message/delete-message.component';
import { MessageItemComponent } from './components/message-item/message-item.component';

@NgModule({
  declarations: [
    AppComponent,
    GroupMessagesComponent,
    RoomListItemComponent,
    DeleteMessageComponent,
    MessageItemComponent,
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatSliderModule,
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        NgxRerenderModule,
        FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
