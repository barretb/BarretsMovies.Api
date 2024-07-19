export class Genre {
    public id: string;
    public title: string;
    public movies: string[];
    public totalMovies: number;

    constructor(){
        this.id = "";
        this.title = "";
        this.movies = [];
        this.totalMovies = 0;
    }
}