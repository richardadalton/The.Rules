The.Rules

This library allows predicates about a domain to be created and combined using various operators (AND, OR, NOT, IMPLIES, etc.) 

This allows a significant portions of complex nested IF style code to be removed from the codebase and replaced with a cleaner representation of the business rules.

### Example:


var cashRich = ARuleAbout<Customer>.Where(c => c.CashBalance > 500000);
var local = ARuleAbout<Customer>.Where(c => c.Country == "IE");
var elderly = ARuleAbout<Customer>.Where(c => c.Age > 60);

var targetF



##Install

##Getting Started

##Examples

