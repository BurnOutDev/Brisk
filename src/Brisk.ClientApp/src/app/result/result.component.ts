import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  @Input() score: number;
  @Input() count: number;

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  playAgain() {
    this.router.navigateByUrl('play');
    console.log('play');
  }

}
