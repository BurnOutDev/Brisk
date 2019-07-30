import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  isExpanded = false;

  showBack = false;

  // public get showBack(): boolean {
  //   console.log(!this.router.url.includes('play'));
  //   console.log('URL');
  //   return !this.router.url.includes('settings') || !this.router.url.includes('play');
  // }


  constructor(
    private location: Location,
    private router: Router) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  goBack() {
    this.location.back();
  }

  goTo(url: string) {
    this.router.navigateByUrl(url);
  }
}
