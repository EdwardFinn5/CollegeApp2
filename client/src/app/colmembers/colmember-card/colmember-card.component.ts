import { Component, Input, OnInit } from '@angular/core';
import { ColMember } from 'src/app/_models/colMember';

@Component({
  selector: 'app-colmember-card',
  templateUrl: './colmember-card.component.html',
  styleUrls: ['./colmember-card.component.css'],
})
export class ColmemberCardComponent implements OnInit {
  @Input() colMember: ColMember;

  constructor() {}

  ngOnInit(): void {}
}
