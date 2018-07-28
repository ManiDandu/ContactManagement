# ContactManagement

This application is to maintain Contacts and CRUD operations on them from UI. 

Below are the functionalities that this application provides

List contacts - All the contacts will be listed in the UI
Add a contact - User can able to add a contact
Edit contact - User can able to update a contact
Delete/Inactivate a contact - User can able to inactive a contact.

Contact model has the below fields.
- First Name
- Last Name
- Email
- Phone Number
- Status (Possible values: Active/Inactive)


Technologies: 

.Net Web API - Rest services to serve all the CRUD operations.
Angular 6 - UI layer
json - Data storage
MS Unit test framework - Unit tests


Instructions to Set up the application:
- Please download the solution and save into a local disk.
- open the solution in VS 2015 or higher version
- Run the service project(ContentManagement)
- Run Angular project(ContentManagementWeb)
  - To run the angular application locally(development mode), you should have npm installed.
  - Open commandprompt at the below location type below command to load the angular page
    location: ContactManagement\ContactManagementWeb\my-app
    command: ng serve --open
    
