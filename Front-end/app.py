# from _typeshed import Self
from datetime import datetime
from typing import Optional
import flask
import requests
import json
from flask.wrappers import Response
from flask import Flask, config,redirect,url_for,render_template , request
from requests.api import post
import json
import ast

from requests.sessions import Request



app = Flask(__name__, template_folder="./templates")
geturl = "https://localhost:5001/books"
headings = ('id','Title' , 'Authors' , 'AverageRating' , 'NumPage' , 'RatingCount' , 'ReviewCount', 'PublicationDate' , 'Publisher','CreatedDate')
request_object = request("https://localhost:5001")
# POST /index
@app.route("/index/" , methods=["GET"])
def index():
    print("1")
    r = request_object.get_request('/books')
    if r != None:
        print("2")
        data_table = json.loads(r)
        print("3")
        return render_template("index.html" ,headings=headings , data=data_table)
    else:
        return render_template("index.html" )

# POST /createbook      
@app.route("/createbook/", methods=["GET","POST"])
def createbook():
    if request.method == "POST" and request.form.get('submit_book') == "submit":
        data_json = {}
        data_json['Title'] = request.form["Title"]
        data_json['Authors'] = request.form["Authors"]
        data_json['AverageRating'] = request.form["AverageRating"]
        data_json['NumPage'] = request.form["NumPage"]
        data_json['RatingCount'] = request.form["RatingCount"]
        data_json['TextReviewCount'] = request.form["TextReviewCount"]
        data_json['PublicationDate'] = request.form["PublicationDate"]
        data_json['Publisher'] = request.form["Publisher"]
        headers = {'Content-type': 'application/json'}
        r = requests.post(url = "https://localhost:5001/books", data = json.dumps(data_json) , verify=False, headers=headers)
        if r.status_code == 200:
            return redirect('/index/')
        else:
            pass

    else:
        return render_template("createbook.html")

# GET /search 
@app.route("/search", methods=["GET"])
def search():
    if request.form.get('search') == "search":
        headers = {'Content-type': 'application/json'}
        r = requests.get(url = "https://localhost:5001/books/search", verify=False, headers=headers)
        if r.status_code == 200:
            data_table = json.loads(r.text)
            return render_template("search.html" ,headings=headings , data=data_table)
        else:
            print('something is wrong on the request', r.status_code) 
    else:
        return render_template("search.html")
    
if __name__== "__main__":
    app.run(debug=True, port="3000")