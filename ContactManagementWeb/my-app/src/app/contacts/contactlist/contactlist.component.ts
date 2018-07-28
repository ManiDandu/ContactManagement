import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/contact.service';
import { Contact } from '../shared/contact.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contactlist',
  templateUrl: './contactlist.component.html',
  styleUrls: ['./contactlist.component.css']
})
export class ContactlistComponent implements OnInit {


    constructor(private contactService: ContactService, private toastr: ToastrService) { }
    
    ngOnInit() {
        this.contactService.getContactList();
 
    }

    showForEdit(con: Contact) {
        this.contactService.selectedContact = Object.assign({}, con);
    }
    onDelete(id: number) {
        if (confirm('Are you sure to delete this record ?') == true) {
            this.contactService.deleteContact(id)
                .subscribe(x => {
                    this.contactService.getContactList();
                    this.toastr.warning("Deleted Successfully", "Contact Register");
                })
        }
    }
}