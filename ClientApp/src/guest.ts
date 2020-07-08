export interface Guest {
  GuestId: number;
  name: string;
  email: string;
  friends: number;
  rsvp: string;
  message: string;
  eventId: number;
}

export const GUESTS: Guest[] = [
  {
    GuestId: 1,
    name: "Santa Claus",
    email: "nick@northpole.com",
    friends: 1,
    rsvp: "yes",
    message: "Ho ho ho",
    eventId: 1
  },
  {
    GuestId: 2,
    name: "The Grinch",
    email: "green@seuss.com",
    friends: 0,
    rsvp: "no",
    message: "...",
    eventId: 1
  }
];
