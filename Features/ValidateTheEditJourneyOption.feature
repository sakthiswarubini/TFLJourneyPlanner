Feature: Validate The Edit Journey Option

Verify the journey can be amended using 'Edit journey' button on Journey result page

Background: 
Given I launch the TFL website

Scenario: Verify the Edit Journey button on Journey Results page
	When I enter the 'valid' From location as 'London Bridge'
	When I enter the 'valid' To location as 'Baker Street Underground Station'
	And I click Plan my journey button
	When I click on Edit journey button in journey results page 
	Then I can amend the Journey details
	And I can update the changes by clicking Update Journey button
	
