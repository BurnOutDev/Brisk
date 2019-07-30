import { Component, OnInit } from '@angular/core';
import { Quote } from '../core/models/quote.model';
import { ToastrService } from 'ngx-toastr';
import { Author } from '../core/models/author.model';
import { QuotesService } from '../core/services/quotes.service';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-quote-management',
  templateUrl: './quote-management.component.html',
  styleUrls: ['./quote-management.component.css']
})
export class QuoteManagementComponent implements OnInit {

  quotes$: BehaviorSubject<Quote[]>;
  authors$: BehaviorSubject<Author[]>;


  filter: string;
  quotesCount: number;

  collapsed: boolean[] = new Array(2000);

  constructor(
    private router: Router,
    private quotesService: QuotesService,
    private toastrService: ToastrService) {

    this.quotes$ = new BehaviorSubject<Quote[]>(undefined);
    this.authors$ = new BehaviorSubject<Author[]>(undefined);
    this.quotesCount = 0;
  }

  ngOnInit() {
    this.quotesService.getPaginatedAndFiltered$(0).subscribe(
      (quote) => {
        this.quotes$.next(quote);
      }
    );

    this.quotesService.getAuthors$().subscribe(
      (author) => {
        this.authors$.next(author);
      }
    );
  }

  onScroll(event: Event) {
    this.toastrService.info("scrolled");
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
    this.quotesService.put$(quote.id, quote).subscribe((u) => {
      this.toastrService.success(`Quote updated`);
    }, (error) => {
      this.toastrService.error(error.message);
    });
  }

  deleteQuote(quote: Quote) {
    this.quotesService.delete$(quote.id).subscribe(this.success, this.error);
  }

  navigateToEdit(quote: Quote) {
    this.router.navigateByUrl(`quote-edit/${quote.id}`);
  }

  onFilterChange() {
    this.quotesService.getPaginatedAndFiltered$(0, this.filter).subscribe(
      (quote) => {
        this.quotes$.next(quote);
      }
    );
  }

  loadMore() {
    this.quotesService.getPaginatedAndFiltered$(this.quotesCount, this.filter).subscribe(
      (quote) => {
        this.quotes$.next(quote);
        this.quotesCount *= environment.defaultTake;
      });
  }
}
