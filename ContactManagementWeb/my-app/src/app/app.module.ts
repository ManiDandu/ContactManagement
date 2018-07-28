import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule }   from '@angular/forms';

import { ToastrModule } from 'ngx-toastr';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactComponent } from './contacts/contact/contact.component';
import { ContactlistComponent } from './contacts/contactlist/contactlist.component';
@NgModule({

  declarations: [
    AppComponent,
    ContactsComponent,
    ContactComponent,
    ContactlistComponent
  ],
  imports: [
      BrowserModule, HttpModule, FormsModule,
      ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
