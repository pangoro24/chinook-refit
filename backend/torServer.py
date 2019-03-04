# from tornado import httpserver
# from tornado import gen
# import tornado.web
import sqlite3
from tornado.web import (Application, RequestHandler)
from tornado.ioloop import IOLoop
import json

sqlite_file = './files/chinook.db'



conn = sqlite3.connect(sqlite_file)
cu = conn.cursor()
print('Connected to db')


class PageHandler(RequestHandler):
    def json_response(self, data, status_code=200):
        self.set_status(status_code)
        self.set_header("Content-Type", 'application/json')
        self.write(data)

    def json_error(self):
        self.json_response({'message': 'body is empty'}, 404)


class ArtistsHandler(PageHandler):
    def get(self):
        cu.execute("SELECT * FROM artists")
        all_rows = cu.fetchall()
        lst2 =[]
        for i in all_rows:
            v = {}
            v["ArtistId"] = i[0]
            v["Name"] = i[1]
            lst2.append(v)
        print('Artists listed')
        self.write(json.dumps(lst2))

class CustomerHandler(PageHandler):
    def get(self):
        email = self.get_argument('email')
        print('Searching by email: ',email)
        if email:
            cu.execute('''SELECT *
                            FROM customers
                          WHERE  email =?''', (email,))
            all_rows = cu.fetchall()
            if(len(all_rows) >0):
                lst2 =[]
                for i in all_rows:
                    v = {}
                    v["CustomerId"] = i[0]
                    v["FirstName"] = i[1]
                    v["LastName"] = i[2]
                    v["Company"] = i[3]
                    v["Address"] = i[4]
                    v["City"] = i[5]
                    v["State"] = i[6]
                    v["Country"] = i[7]
                    v["PostalCode"] = i[8]
                    v["Phone"] = i[9]
                    v["Fax"] = i[10]
                    v["Email"] = i[11]
                    v["SupportRepId"] = i[12]
                    lst2.append(v)
                print(lst2[0])
                self.write(json.dumps(lst2[0])) #send as dict, not as list
            else:
                print("No customer found with email: ",email)
                self.json_error()
        else:
            print("error in GET")
            self.json_error()

class SearchAlbumsHandler(PageHandler):
    def get(self, name=None):
        print('Searching: ',name)
        if name:
            cu.execute('''SELECT ar.Name AS ArtistName,
                               al.Title AS AlbumName
                          FROM artists ar
                               JOIN
                               albums al ON ar.ArtistId = al.ArtistId
                         WHERE ar.Name LIKE ?
                         ORDER BY ar.Name ASC''', (name+'%',))
            all_rows = cu.fetchall()
            lst2 =[]
            for i in all_rows:
                v = {}
                v["ArtistName"] = i[0]
                v["AlbumName"] = i[1]
                lst2.append(v)
            print(lst2)
            self.write(json.dumps(lst2))
        else:
            print("error in GET")
            self.json_error()

class SearchTracksHandler(PageHandler):
    def get(self, name=None):
        print('Searching: ',name)
        if name:
            cu.execute('''SELECT tk.Name AS TrackName,
                                 al.Title AS AlbumName,
                                 tk.Milliseconds / 1000 AS Duration
                           FROM tracks tk
                                JOIN
                                albums al ON tk.AlbumId = al.AlbumId
                           WHERE al.Title LIKE ?''', (name+'%',))
            all_rows = cu.fetchall()
            lst2 =[]
            for i in all_rows:
                v = {}
                v["TrackName"] = i[0]
                v["AlbumName"] = i[1]
                v["Duration"] = i[2]
                lst2.append(v)
            print(lst2)
            self.write(json.dumps(lst2))
        else:
            print("error in GET")
            self.json_error()


class InitialiseApp(Application):
    def __init__(self):
        handlers = [
            (r"/api/v1/artistsAll",ArtistsHandler),
            (r"/api/v1/customer/",CustomerHandler),
            (r"/api/v1/albumsByArtist/([^/]+)?" , SearchAlbumsHandler),
            (r"/api/v1/tracksOfAlbum/([^/]+)?" , SearchTracksHandler),
        ]

        server_settings = {
            "debug": True,
            "autoreload": True
        }
        Application.__init__(self, handlers, **server_settings)




def run_server():
    app = InitialiseApp()
    app.listen(3000)
    print('Server is up')
    IOLoop.instance().start()
    


if __name__ == '__main__':
    run_server()
