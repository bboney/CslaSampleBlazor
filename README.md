# CslaSampleBlazor
 A Sample App for testing CSLA and Blazor

 This branch (using-sqlconnection-inject) fails.

 Error in DAL when creating DataReader: Invalid operation. The connection is closed.
 Seems like DI is not injecting new SQLConnection instances everytime

  - DAL Classes are Injected into DataPortal Methods
  - Not using ConnectionManager
  - SqlConnection Injection into DAL using a Transient instance
