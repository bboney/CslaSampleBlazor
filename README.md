# CslaSampleBlazor
 A Sample App for testing CSLA and Blazor

 This branch (using-connection-manager) fails most of the time.
  - It actually works every other time, however, there is a 30 second delay before the app appears in the browser
  - The other time, I get this error on the DataReader: Connection broken 

  - DAL Classes are Injected into DataPortal Methods
  - ConnectionManager is Injected into DAL
  - Not using SqlConnection Injection into DAL
