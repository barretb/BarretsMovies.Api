import { Component, OnDestroy, OnInit } from '@angular/core';
import { GenresComponent } from '../genres/genres.component';
import { MovieApiService } from '../services/movieapiservice';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { debounceTime, fromEvent, Subject } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [GenresComponent, CommonModule, RouterLink, FormsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent implements OnInit, OnDestroy {
  private titleSubject = new Subject<string>();
  private actorSubject = new Subject<string>();
  private directorSubject = new Subject<string>();
  private writerSubject = new Subject<string>();
  public titleText: string = '';
  public actorText: string = '';
  public directorText: string = '';
  public writerText: string = '';
  public pageSize: number = 25;
  public pageSizes: number[] = [10, 25, 50, 100, 1000];
  public mpaaRatings: string[] = [
    'G',
    'PG',
    'TV-14',
    '14A',
    'R',
    '18A',
    'AA',
    'A',
    'Approved',
    '(Banned)',
    'Not Rated',
    '18+',
    'Passed',
    '13+',
    'PG-13',
    'PA',
    '16+',
    '14+',
    '14',
    'TV-MA',
  ];
  public mpaaRating: string | null = "Any";

  constructor(protected movieApiService: MovieApiService) {
    if (movieApiService.movies.length === 0) {
      movieApiService.getMovies(null);
    }
  }

  ngOnInit() {
    this.titleSubject.pipe(debounceTime(300)).subscribe((searchValue) => {
      this.movieApiService.currentTitleFilter = searchValue;
      this.movieApiService.getMovies(null);
    });
    this.actorSubject.pipe(debounceTime(300)).subscribe((searchValue) => {
      this.movieApiService.currentActorFilter = searchValue;
      this.movieApiService.getMovies(null);
    });
    this.directorSubject.pipe(debounceTime(300)).subscribe((searchValue) => {
      this.movieApiService.currentDirectorFilter = searchValue;
      this.movieApiService.getMovies(null);
    });
    this.writerSubject.pipe(debounceTime(300)).subscribe((searchValue) => {
      this.movieApiService.currentWriterFilter = searchValue;
      this.movieApiService.getMovies(null);
    });
  }

  ngOnDestroy(): void {
    this.titleSubject.complete();
    this.actorSubject.complete();
    this.directorSubject.complete();
    this.writerSubject.complete();
  }

  pageSizeChange(newValue: any) {
    this.movieApiService.changePageSize(this.pageSize);
  }

  ratingChange(event: any) {
    if (this.mpaaRating === 'Any') {
      this.movieApiService.mpaaRating = null;
    } else {
      this.movieApiService.mpaaRating = this.mpaaRating;
    }
    this.movieApiService.getMovies(null);
  }

  searchTitle() {
    this.titleSubject.next(this.titleText);
  }

  searchActor() {
    this.actorSubject.next(this.actorText);
  }

  searchDirector() {
    this.directorSubject.next(this.directorText);
  }

  searchWriter() {
    this.writerSubject.next(this.writerText);
  }

  goToNextPage() {
    this.movieApiService.getMovies(this.movieApiService.currentPage + 1);
  }

  goToPrevPage() {
    this.movieApiService.getMovies(this.movieApiService.currentPage - 1);
  }
}
