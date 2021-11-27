from enum import Enum 
from requests

class methods(Enum):
    POST = "POST"
    GET = "GET"
    PUT = 'PUT'
 
class Request:
    def __init__(self,base_url) -> None:
        self.base_url = base_url
        self.method = methods.GET
    
    def error_handlerer(self):
        return "somthing is wrong , try again"
    def get_request(self,postfix_url, method= methods.GET ,url_params = None ):
        if method == methods.GET:
            headers = {'Content-type': 'application/json'}
            if url_params != None:
                r = requests.get(url = self.baseUrl + postfix_url, verify=False, headers=headers)
            else:
                r = requests.get(url = self.baseUrl + postfix_url, params=url_params , verify=False, headers=headers)
            
            if r.status_code == 200:
                return r.text
            else:
                return error_handlerer()



