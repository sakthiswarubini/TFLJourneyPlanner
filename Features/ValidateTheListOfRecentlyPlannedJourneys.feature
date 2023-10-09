Feature: Validate The List Of Recently Planned Journeys

Verify the 'Recent' tab dispaly a list of recently planned journeys

Background: 
Given I launch the TFL website

Scenario: Verify the Recent tab displays recently planned journeys
	When I enter the 'valid' From location as 'London Bridge'
	When I enter the 'valid' To location as 'Baker Street Underground Station'
	And I click Plan my journey button
	When I click on Edit journey button in journey results page 
	Then I can amend the Journey details
	And I can update the changes by clicking Update Journey button
	When I click Plan a Journey link
	When I enter the 'valid' From location as 'London Bridge'
	When I enter the 'valid' To location as 'Baker Street Underground Station'
	And I click Plan my journey button
	When I click Plan a Journey link
	Then I validate the recent journey results
