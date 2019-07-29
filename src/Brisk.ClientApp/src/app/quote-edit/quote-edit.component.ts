import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Quote } from '../core/models/quote.model';
import { Author } from '../core/models/author.model';
import { QuotesService } from '../core/services/quotes.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-quote-edit',
  templateUrl: './quote-edit.component.html',
  styleUrls: ['./quote-edit.component.css']
})
export class QuoteEditComponent implements OnInit {

  public state$: Observable<Quote>;

  public authors$: Observable<Author[]>;

  constructor(
    public quotesService: QuotesService,
    public toastrService: ToastrService,
    public activatedRoute: ActivatedRoute) {
    this.authors$ = quotesService.getAuthors$();
  }

  ngOnInit() {
    this.state$ = this.activatedRoute.paramMap
      .pipe(map(() => {
        console.log(window.history.state);
        return window.history.state as Quote;
      }))

    // this.state$.pipe(map(state => {
    //   this.quote = state;
    // }));
  }

  update(quote: Quote) {
    this.quotesService.put$(quote.id, quote).subscribe(() =>
      this.toastrService.success('quote updated'), (error) =>
        this.toastrService.error(error.message));
  }

}
