from _typeshed import Self


class BookModel:

    def __init__(self,json) -> None:
        super().__init__()
        if json is not None:
            self.title = ""
            self.authors = ""
            self.averageRating = ""
            self.numPage = ""
            self.ratingCount = ""
            self.textReviewCount = ""
            self.publicationDate = ""
            self.publisher = ""
            self.createdDate = ""
    def map_data(self,json):
        if json is not None:
            self.title = json["title"]
            self.authors = json["auhors"]
            self.averageRating = json["averageRating"]
            self.numPage = json["numPage"]
            self.ratingCount = json["ratingCount"]
            self.textReviewCount = json["textReviewCount"]
            self.publicationDate = json["publicationDate"]
            self.publisher = json["publisher"]
            self.createdDate = json["createdDate"]
