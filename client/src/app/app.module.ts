import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from "@angular/common/http";
import { RoomListComponent } from './components/room-list/room-list.component';
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

@NgModule({
  declarations: [
    AppComponent,
    RoomListComponent,
    GroupMessagesComponent,
    RoomListItemComponent,
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
