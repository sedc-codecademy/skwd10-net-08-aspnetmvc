# Homework - Class 08

Use the SEDC.PizzaApp.Refactored project from Class 08

We need to add a feature for giving feedbacks for the services of our pizza store and pizza app. You will need to implement the whole flow, through
all the three levels of our new architecture. Be careful with the different types of models!

1. Create a model for Feedback that contains the following properties:
- Id (int)
- Name (string) - the name of the visitor that gives feedback 
- Email (string) - email of the visitor that gives the feedback
- Message (string) - content of the feedback

This entity (Feedback) is stand-alone, it doesn't have relations with other tables (entities).

2. Create a repository that handles data access for feedback entities and implements the CRUD operations.

3. Create a service that handles logic for feedbacks.

4. Create a corresponding Controller.

5. Add a menu link in Layout that leads to Feedback page.

6. Implement listing of all feedbacks, inserting a feedback, editing a feedback and deleting a feedback.


## Bonus 1
Maximum three feedbacks are allowed per email. 
Think where should this validation be done (for example, maximum three feedbacks with mail example@example.com are allowed).

## Bonus 2
B1. Make the combination of Pizza and Pizza Size in an Order unique. You can not add again the same Pizza with the same Pizza Size.

B2. Add an action on the order screen for deleting a pizza from an order. You have two options here: choose a pizza and delete all of its occurrences in the PizzaOrders
related to the Order or delete by choosing pizza and pizza size (for example in Order with id 1 the item with pizza with id 1 and Pizza Size 1 should be deleted)

## Bonus **
Check if the email is in correct format. Think where should this validation be done. 

