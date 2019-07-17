# Library

This a coding task for the following scenario.

Creation of a basic book list view based on the following xml.
https://msdn.microsoft.com/en-us/library/ms762271(v=vs.85).aspx
The xml is to be loaded, mapped into objects and the operations then shall be handled in memory.

Use Cases- For  a Person
1. It should be possible to borrow books.
2. In the list view, it should be visible if someone borrowed the book.
4. In the list view, it should be visible if someone returned the book.
5. In the detail view it should be visible who borrowed the book.

Implementation:

Frameworks Used:
1. IOC Framework : Unity
2. Unit Test cases: MS Tests
3. Mocking Framework: MoQ

Configurations:
The project configurations are maintained in LibrarySystem\Config\Custom_Setting.config
1. books   : Specifies the internal or external url source of book.xml. eg:http://localhost:65369/Config/books.xml
2. persons : Specifies the internal or external url source of book.xml. eg:http://localhost:65369/Config/persons.xml
2. loglevel: Specifies the level of logging required for the application. Any of the below values are set.
    1- Error, 2- Warn,Error, 3- Info, Warn, Error, 4-Debug, Info, Warn, Error
    
Notes:
1. A user can borrow book, return book or update the borrowal to any person.
2. The data is maintained in memory in the application. Static variables stores the xml data in the application.
