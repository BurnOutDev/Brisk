import { Injectable } from '@angular/core';
import { tap, map } from 'rxjs/operators';
import { QuotesService } from '../services/quotes.service';
import { Store } from './store';
import { Quote } from '../models/quote.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class QuotesStore extends Store<Quote[]> {

    constructor(private quotesService: QuotesService) {
        super();
    }

    init = (): void => {
        // if (this.getAll()) { return; }

        // this.quotesService.get$().pipe(
        //     tap(this.store)
        // ).subscribe();

        this.getAllPaged(1);
    }

    create$ = (quote: Quote): Observable<Quote> => this.quotesService
        .post$(quote)

    update$ = (quoteId: number, quote: Quote) => this.quotesService
        .put$(quoteId, quote)

    delete$ = (quoteId: number) => this.quotesService
        .delete$(quoteId)
        .pipe(
            tap(() => {
                const quotes = this.getAll();
                const quoteIndex = this.getAll().findIndex(item => item.id === quoteId);
                quotes.splice(quoteIndex, 1);

                this.store(quotes);
            })
        )

    getAllPaged(page: number) {
        this.getAll();

        return this.quotesService.getPaged$(page).pipe(
            tap(this.store)
        ).subscribe();
    }

}