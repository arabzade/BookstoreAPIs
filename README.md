Follow the below steps to run the application and use the APIs through Postman

- Intsall MongoDb - https://docs.mongodb.com/manual/installation/

- Run the app with Visual Studio

- Run the APIs via Postman

Here is some examples of APIs:

URL: https://localhost:5001/books
POST
Body:
{
    "Title" : "The stranger version 2",
    "Authors" : "Matthew Ward",
    "AverageRating" : "4.3",
    "NumPage" : "85",
    "RatingCount" : "450000",
    "TextReviewCount" : "32000",
    "PublicationDate" : "01-05-2021",
    "Publisher" : "Local book store"
}

URL: https://localhost:5001/books
GET

# Search by Id

URL: https://localhost:5001/books/fa19dcf3-17c8-438a-b4f9-58788cac97b4
GET

#Search by:
- title
- authors
- min number of pages
- max number of pages

URL: https://localhost:5001/books/search?Title=ha&Authors=ha&MinNumPage=1&MaxNumPage=500
GET


