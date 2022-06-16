Homework - Class 02
Work with the SEDC.PizzaApp

Create new Controller for managing Orders (name it accordingly)

Add Index action that returns a view with a simple html that says “List of orders”. It should be accessed through custom route http://localhost:[port]/ListOrders

Add Details action with optional parameter id. If id is null it should return empty action result, else it should return a view with simple html. It should be accessed through route http://localhost/[Controller Name]/Details/{id?}

Add an action that returns Json (create an example model, class by your choice), it should be accessed by http://localhost/[Controller Name]/JsonData.

Add an action that redirects to Action Index in Home Controller.

Bonus
Create model for Order and static list consisting of several orders. Use it in the Details action (refer to the demo for hint)