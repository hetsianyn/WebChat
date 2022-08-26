import {Message} from "./message";
import {Room} from "./room";

export interface RoomDetailed extends Room{

  messages: Message[];
}
