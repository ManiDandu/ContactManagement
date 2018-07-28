import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/toPromise';
import { map } from 'rxjs/operators';



import {Contact} from'./contact.model'

@Injectable()
export class ContactService {
    selectedContact: Contact;
    contactList: Contact[];
    constructor(private http: Http) { }

    addContact(con: Contact) {
        var body = JSON.stringify(con);
        var headerOptions = new Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new RequestOptions()
        requestOptions.method = RequestMethod.Post;
        requestOptions.headers = headerOptions;
        return this.http.post('http://localhost:59578/api/ContactInfo/AddContact', body, requestOptions);
    }

    editContact(con: Contact) {
        var body = JSON.stringify(con);
        var headerOptions = new Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new RequestOptions();
        requestOptions.method = RequestMethod.Post;
        requestOptions.headers = headerOptions;
        return this.http.post('http://localhost:59578/api/ContactInfo/EditContact', body, requestOptions);
    }

    getContactList() {
        this.http.get('http://localhost:59578/api/ContactInfo/GetContactList').pipe(map((data: Response) => {
                return data.json() as Contact[];
            })).toPromise().then(x => {
                this.contactList = x;
            })
    }

    deleteContact(id: number) {
        var body = JSON.stringify(id);
        var headerOptions = new Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new RequestOptions()
        requestOptions.method = RequestMethod.Post;
        requestOptions.headers = headerOptions;
        return this.http.post('http://localhost:59578/api/ContactInfo/DeleteContact', body, requestOptions);
    }
}