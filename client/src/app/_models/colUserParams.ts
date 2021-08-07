import { ColUser } from './colUser';

export class ColUserParams {
  colUserType: string;
  minEnrollment = 300;
  maxEnrollment = 6000;
  collegeLocation = 'Des Moines, IA';
  collegeName: string;
  pageNumber = 1;
  pageSize = 3;
  classYear = 'Junior';
  proposedMajor = 'Accounting';

  orderBy = 'lastActive';

  constructor(colUser: ColUser) {
    this.colUserType =
      colUser.colUserType === 'College' ? 'ColLead' : 'College';
  }
}
