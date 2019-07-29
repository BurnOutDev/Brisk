import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Quote } from '../core/models/quote.model';
import { ToastrService } from 'ngx-toastr';
import { QuotesStore } from '../core/stores/quotes.store';
import { map } from 'rxjs/operators';
import { Author } from '../core/models/author.model';
import { QuotesService } from '../core/services/quotes.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-quote-management',
  templateUrl: './quote-management.component.html',
  styleUrls: ['./quote-management.component.css']
})
export class QuoteManagementComponent implements OnInit {

  quotes$: Observable<Quote[]>;
  authors$: Observable<Author[]>;

  collapsed: boolean[] = new Array(2000);

  constructor(private quotesStore: QuotesStore,
    private router: Router,
    private quotesService: QuotesService,
    private toastrService: ToastrService) {
    this.quotesStore.init();
  }

  ngOnInit() {
    this.quotes$ = this.quotesStore.getAll$();
    this.authors$ = this.quotesService.getAuthors$();
  }

  onScroll(event: Event) {
    this.toastrService.info("scrolled");
    // this.quotesStore.getAllPaged(2);
    // this.quotes$ = this.quotesStore.getAll$();
  }

  success() {
    this.toastrService.success("Success");
  }

  error() {
    this.toastrService.error("Error");
  }

  createQuote(quote: Quote) {
    // this.quotes$.pipe(
    //   map(data =>
    //     data.push()));
  }

  updateQuote(quote: Quote) {
    console.log("update pressed");
    this.quotesStore.update$(quote.id, quote).subscribe((u) => {
      this.toastrService.success(`Quote updated`);
    }, (error) => {
      this.toastrService.error(error.message);
    });
  }

  deleteQuote(quote: Quote) {
    this.quotesStore.delete$(1).subscribe(this.success, this.error);
  }

  navigateToEdit(quote: Quote) {
    this.router.navigateByUrl('quote-edit', { state: quote });
  }
}
