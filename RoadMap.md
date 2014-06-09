#RoadMap

## Documentation
* Write the ReadMe.md Doc
* Create QuickStart Guide

## Rule Types
* Allow Multi-Type Rules
	e.g. ARuleAbout<Customer, Account>

* Allow Operators to create Multi-Type Rules
	e.g. ARuleAbout<Customer> AND ARuleAbout<Account> = ARuleAbout<Customer, Account>
	     ARuleAbout<Customer, Account> AND ARuleAbout<Order> = ARuleAbout<Customer, Account, Order>

* Allow Lists of Rules

    e.g. NoneOf(rule1, rule2, rule3);
	     OneOf(rule1, rule2, rule3);
		 AnyOf(rule1, rule2, rule3);
		 AllOf(rule1, rule2, rule3);
	     	
## Describing Rules
* Prune Unneeded Branches for Evaluated Description
    e.g. A and (B OR C)
	     if A is false, (B OR C) is irrelevant

* Describe Multi-Type Rules


## Refactoring
* There's a lot of duplication in the various handlers of a Rule Describer, should be possible to simplify.

* Might be possible to create Describer behaviours (Prune, Remove Parenthesis, Location of result)
  Describers could then be created by composing these behaviours.

* The current example of a custom describer should be in the core framework, and create a new example.
