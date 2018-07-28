import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/contact.service';
import { NgForm } from '@angular/forms'
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
    public statuses: any[] = [
        "--Select--", "Active", "InActive"
    ];
    constructor(private contactService: ContactService, private toastr: ToastrService) { }

    ngOnInit() {
        this.resetForm();
    }

    resetForm(form?: NgForm) {
        if (form != null)
            form.form.reset();
        this.contactService.selectedContact = {
            ContactID: null,
            FirstName: '',
            LastName: '',
            EMail: '',
            PhoneNumber: '',
            Status: ''
        }
    }

    onSubmit(form: NgForm) {
        if (form.value.ContactID == null) {
            this.contactService.addContact(form.value)
                .subscribe(data => {
                    this.resetForm(form);
                    this.contactService.getContactList();
                    this.toastr.success('New Record Added Succcessfully', 'Contact Register');
                })
        }
        else {
            this.contactService.editContact(form.value)
                .subscribe(data => {
                    this.resetForm(form);
                    this.contactService.getContactList();
                    this.toastr.info('Record Updated Successfully!', 'Contact Register');
                });
        }
    }
}