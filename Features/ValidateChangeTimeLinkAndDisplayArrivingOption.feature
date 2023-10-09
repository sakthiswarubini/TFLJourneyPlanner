Feature: Validate Change Time Link Display Arriving Option

Verify change time link on the journey planner displays "Arriving" option and plan a journey based on arrival time

Background: 
Given I launch the TFL website

Scenario: Verify change time link displays Arriving option
	When I enter the 'valid' From location as 'London Bridge'
	When I enter the 'valid' To location as 'Baker Street Underground Station'
	And I click on change time link 
	Then I verify 'Arriving' option displays
	And I click Plan my journey button
	#Then I should see the valid journey options in Journey results page
	Then I should see the journey based on Arrival time



