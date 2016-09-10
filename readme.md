Locally cachable AppSettings with Read/Write options
====================================================

The purpose of this project is to demonstrate a possible solution to a problem of caching application settings
and how those settings might be made accessible to an application. 

A major design constraint in these examples is the fact that the *consuming framework is based on statics*.

* will be used in XAML models: design mode which means that any storage of settings should support run-time and design time sources
* need capability to update the application settings
* need examples of supporting largely read-only settings but read-write(local only) settings for design time
* settings are persisted via other means and is not part of this example
* must be testable and design driven with testing during the development

The application settings are strongly typed and T4'd out of a database. In the T4 folder are the dependencies
that would produced via that mechanism. Using partial classes would help keep the .tt files clean but I did not
attempt to demonstrate the tt files here.

The examples here make use of xUnit and Moq. I ran the tests in VS 2015 Community Edition using TestDriven.Net.


