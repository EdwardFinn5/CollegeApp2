export interface Message {
  id: number;
  senderId: number;
  senderColUsername: string;
  senderFirstName: string;
  senderCollegeName: string;
  senderHsName: string;
  senderColUserType: string;
  senderHsPhotoUrl: string;
  senderCollegePhotoUrl: string;
  recipientHsPhotoUrl: string;
  recipientCollegePhotoUrl: string;
  recipientId: number;
  recipientColUsername: string;
  recipientFirstName: string;
  recipientCollegeName: string;
  recipientHsName: string;
  recipientColUserType: string;
  content: string;
  dateRead?: Date;
  messageSent: Date;
}
