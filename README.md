# Software Development w/ Frameworks (C#) Coursework



 Each of the labs have a corresponding folder above which contains ..

- the **Solution Folder**

- 1-2 .pdf files

  - the **CODE & OUTPUT**
  - a short **SUMMARY/REFLECTION** of what I learned

  

<u>**Table of Contents:**</u>

[toc]

-------

### Lab1: Calculator Program

First C# program where we created a ==**class**== (`Calculator.cs`) & a corresponding ==**class library**== to support calculator operations (`CalculatorLibrary.cs`).



### Lab2: IntegerSets Program

A program which implements the ==**IntegerSet** data structure== (`IntegerSet.cs`) and methods to determine the **Union** or **Intersection** between two IntegerSets and whether a given IntegerSet **isEqualTo()** the current IntegerSet.



### Lab3: Stock Program

A program which sends `StockBroker`'s a `StockNotification` when the value of a `Stock` they are subscribed to has changed. This program ...

- Implements the ==**Observer Design Pattern**== where we have publishers (`Stock.cs`) & subscribers (`StockBroker.cs`).
- Implements a specific kind of built-in ==**delegate method**== supported by the .NET Framework, the Event Handler delegate, which usually takes in 2 parameters: the object of interest & an object of type `EventArgs`. 
  - For this program, we created ==**a custom EventArgs class**== `StockNotification.cs` so that ==**1+ fields of data**== can be passed on to the EventHandler method in StockBroker, `stock_StockValueChanged()`.)
- ==**Raises & consumes events**==
  - To raise an event, after an event occurs or happens to an object (once the value of a stock changes in our case) we call the object’s protected and virtual method (usually with a prefix of “On”) after the process is finished (ie. `OnStockValueChanged()`). Here is where we “**raise**” the event as the method is what invokes the Stock’s Event Handler delegate, `StockValueChanged`. Once the delegate is invoked, any class (ie. `StockBroker`) who has “registered” to this Event-Handler delegate will be “notified” and their respective method(s) (ie. `stock_StockValueChanged()`) will be called as well.
  - Implements ==**threads & locks**== to simulate changes to stocks' values.
  
  

### Lab4A: ExpenseIt App & HelloWorldWPFMVVM App

##### -> ExpenseIt:

- An application made following a tutorial to become familiar with the **WPF Framework** & XAML code.

##### -> HelloWorldWVVM:

- An application made following a tutorial using the **WPF Framework**, the **MVVMLight Toolkit**, & its Messenger class (based on the ==**Model-View-Controller Pattern**==), which allows a **Sender** to send a **Message** to a **Receiver.**
- We specifically learned how to ...
  - ==**Bind ViewModels with Views**== using a ModelLocator class
  - ==**Bind data to the View**== using the ViewModel's properties, actions or events by using RelayCommands (ie. "OnClickCommand")
  - ==**Send data between Views**==



### Lab4B: Calculator App

##### -> Calculator App:

- My first application made based off of the previous lab (`HelloWorldMVVM`) following the same ==**Model-View-ViewModel (MVVM) pattern**==. Similarly, we also have a Message containing data being sent between 2 Views -- this time I created my own calculator to practice more ==**Data Binding**==, specifically focused on implementing more RelayCommands & action methods, rather than a simple text message to be sent by one & read by another.

  

### Lab5: GymMembership App

An application to help solidify understanding of the ==**Model-View-ViewModel (MVVM) Pattern**== & how to send data between different views -- this time we implemented more than just two views, Sender & Receiver, and instead had multiple different views to send data between, including `AddView`, `ChangeView`, & `UpdateView`, in order to be able to add, update, and delete our database of `GymMember`'s & immediately update the view to reflect those changes. Similar to a previous lab, the `Stock Program`, we sent data between views in the form of an instance of a custom `Message`-type class, `MessageMember.cs`, from the MVVMLight Toolkit's Messenger class in order to send more than one fields of data between views. 



### Lab6: Stock Program (Redone) & BooksDatabase App

##### -> Stock Program (Redone):

- Lab3 (`Stock Program`) redone ==**using semaphores & implementing `async()` and `await()` to enable synchronization**==.

##### -> BooksDatabase App:

- An application to help with understanding how to create an ADO.NET Entity Data Model (EDM) from an existing database via the ==**Database-First Approach**== where each entity is mapped with a database table & every Entity Data Model generates a context and entity class for each database table. 
- We also familiarize ourselves with the Entity Framework's context class, ==**DbContext class**== (and its methods) which acts as the middle-man between the database and our entities & the ==**DbSet class**== (and its methods) to support create, read, update, and delete operations.
- We also learned how to create an instance of the context class which implements `DbContext` & use ==**LINQ queries**== to operate on `DbSet`-type properties to access data from the database.



### Lab7: SchoolDatabase App

An application made following the ==**Generic Repository Pattern**== so that a repository does not need to be made for each and every entity. The repository serves as a middle man between the ==**Database**== & ==**the Business Logic layer**==. The repository is responsible for reading and writing data or specific rows of data from and to our database, while the business layer is responsible for providing the repository with more specific information or attributes for the repository to search for in the database. From our main program, by separating it from anything to do with databases or business logic, we can then focus more on the flow of our program, how it should function, and displaying data to the user rather than reading and writing to our database. We only have to request the business layer for specific rows we want or tell it to update a specific object we deal with in our program, but we do not have to deal with any other part of our database now that we have a business layer and database context to deal with these separately. We also learned how having an ==**enum**== to represent an Entity’s current state is handy so that we don’t have to worry about updating other entities within the database to reflect changes in other entities.



### Lab8: FlickrViewer App

An application to become familiar with how to use FlickrAPI & fix the errors and missing code in the program relating to ==**asynchronous programming**== and ==**LINQ queries**==.



### Lab9: MvcMovie App

Introductory web application using the ==**ASP.NET MVC Framework**== (based on the ==**Model-View-Controller Pattern**== where the ==**Controller**== decides which model to use to fulfill a request and passes the ==**Model**=='s data to the ==**View**==, which then transforms the Model data and renders a response to the client) & made following a tutorial to maintain a list of movies (`Model`), learn how to create and redirect to different pages, make **Add**, **Edit** & **Delete** buttons and **Update** the list of movies to reflect those changes, & create a ==**DbContext class**== to query using ==**LINQ**==.



### Lab10: TodoApi App

Introductory web application using the ==**ASP.NET MVC Framework**== & ==**ASP.NET Web API Framework**== for building RESTful, HTTP-based services which supports the ASP.NET request/response pipeline and HttpClient to allow for communication with the Web API server. We maintained a list of TODO items & learned how to **configure Web API** how to create a controller based off the Web API controller class to create ==**Action Methods**== to handle specific ==**Http Requests**==, including **GET, PUT, POST, and DELETE**.



### Lab11:  Bank Program & MyCalculator Program

Introductory web applications made following a tutorial to learn how to do unit testing.



### Lab12: MovieList App

A web application which uses the ==**ASP.NET MVC Framework**== based off of the ==**Model-View-Controller Pattern**==. Here we learn more on how to use the ViewData dictionary object in order to pass data between the Controller & View.
# c-sharp
