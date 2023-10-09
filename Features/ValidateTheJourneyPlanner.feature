Feature: Validate the Valid and Invalid Locations

Validate the journey planner widget with valid and invalid locations

Background: 
Given I launch the TFL website

@validlocation
Scenario: Validate the valid locations in Journey planner widget
	When I enter the 'valid' From location as 'London Bridge'
	When I enter the 'valid' To location as 'Baker Street Underground Station'
	And I click Plan my journey button
	Then I should see the valid journey options in Journey results page

@Invalidlocation
Scenario: Validate the Invalid locations in Journey planner widget
	When I enter the 'invalid' From location as 'Oswestry, UK'
	When I enter the 'invalid' To location as 'Llangollen, UK'
	And I click Plan my journey button
	Then I should see an error notification

	

