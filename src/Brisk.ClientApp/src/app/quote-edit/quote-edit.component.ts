import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
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

  public quote$: BehaviorSubject<Quote>;

  public authors$: BehaviorSubject<Author[]>;

  constructor(
    public quotesService: QuotesService,
    public toastrService: ToastrService,
    public activatedRoute: ActivatedRoute) {
      this.quote$ = new BehaviorSubject<Quote>(undefined);
      this.authors$ = new BehaviorSubject<Author[]>(undefined);

      this.activatedRoute.params.subscribe(params => {
        if(params['id'])
        quotesService.getById$(params['id']).subscribe(quote => this.quote$.next(quote));
      });

    quotesService.getAuthors$().subscribe(author => this.authors$.next(author));
  }

  ngOnInit() { }

  update(quote: Quote) {
    this.quotesService.put$(quote.id, quote).subscribe(() =>
      this.toastrService.success('quote updated'), (error) =>
        this.toastrService.error(error.message));
  }

}
