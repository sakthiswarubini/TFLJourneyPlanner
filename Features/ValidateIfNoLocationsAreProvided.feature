Feature: ValidateIfNoLocationsAreProvided
Validate the journey planner unable to plan a journey when From and To locations are not entered 

Background: 
Given I launch the TFL website


Scenario: Verify error message when From and To locations are empty
When I click Plan my journey button without entering From and To location
Then I should see an error message saying "The From field is required."
And I should see an error message saying "The To field is required."