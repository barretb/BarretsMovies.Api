# Welcome to Barret's Movies

This is a simple web api application in .NET core that allows you to view and search a list of movies. The movies were seeded from a file taken from [this movie repository on Github](https://github.com/thisdot/movies-api), and the endpoints roughly replicate the endpoints in that repo, but I didn't look at any of the logic from that repo or replicate it. I recreated each from scratch based on ideas I had based on creating an [Angular app](https://github.com/barretb/barretsmovies) to hit that repo. 

I created that other repo first, then decided to create a .NET back end. Included in this repo is a modified Angular app from the other repo designed to hit this back end instead of the other one. I also updated the Angular app to add some of the features I added to this back end, such as the ability to filter on directer, actor, writer or rating. I also fixed a couple of the annoyances I found with that other back end, such as paged results not giving you the total count of results. I also updated it to store the user rating in the API dataset instead of browser local storage.

## Potential Future Improvements

* Update the API to store the movies in a database instead of in memory
* Make the API multi-user, with appropriate security/auth, so that each user can have their own ratings and the ratings of all users can be averaged together
* Store movie poster images locally instead of stealing them from another source
* Admin portal to add new movies
* Allow users to add reviews, not just a rating score

## Running the app

1. Run the .NET app first. It will run on http://localhost:5279
1. Once the API is running, run the Angular app. It will run on http://localhost:4200

You can view the readme in the Angular app's folder (barretsmovies) for more information on the Angular app. That readme is just a straight copy from the original repo.